using System;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.StateSelectors;
using GamePlay.Enemies.Entity.Network.EntityHandler;
using GamePlay.Enemies.Entity.Network.Properties.Runtime;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.States.Death.Local;
using GamePlay.Enemies.Entity.States.Respawn.Local;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Setup.Root.Local
{
    public class LocalEnemyRoot : ILocalEnemyRoot
    {
        public LocalEnemyRoot(
            IEnemyEventLoop eventLoop,
            IEntityProvider entityProvider,
            INetworkPropertiesBinder networkPropertiesBinder,
            IStateSelector stateSelector,
            IRespawn respawn,
            IDeath death,
            GameObject gameObject)
        {
            _eventLoop = eventLoop;
            _entityProvider = entityProvider;
            _networkPropertiesBinder = networkPropertiesBinder;
            _stateSelector = stateSelector;
            _respawn = respawn;
            _death = death;
            _gameObject = gameObject;
        }

        private readonly IEnemyEventLoop _eventLoop;
        private readonly IEntityProvider _entityProvider;
        private readonly INetworkPropertiesBinder _networkPropertiesBinder;
        private readonly IStateSelector _stateSelector;
        private readonly IRespawn _respawn;
        private readonly IDeath _death;
        private readonly GameObject _gameObject;

        private bool _isActive;
        private Action<IPoolObject> _returnToPool;

        public GameObject GameObject => _gameObject;

        public void Construct(Action<IPoolObject> returnToPool)
        {
            _returnToPool = returnToPool;
        }

        public async UniTask OnBootstrapped()
        {
            _eventLoop.InvokeAwake();

            _isActive = true;
        }

        public void OnBeforeAttach(RagonEntity entity)
        {
            _entityProvider.SetEntity(entity);
            _networkPropertiesBinder.BindProperties();
            _eventLoop.InvokeEnable();
        }

        public async UniTask OnAttached()
        {
            _eventLoop.InvokeEntityAttached();

            await _respawn.Enter();
            
            _stateSelector.Start();
        }

        public void OnTaken()
        {
            _death.Died += OnDied;
        }

        public void OnReturned()
        {
            _entityProvider.DestroyEntity();
            _death.Died -= OnDied;

            _eventLoop.InvokeDisable();
        }

        public void Enable()
        {
            if (_isActive == true)
            {
                Debug.LogError("Enemy can't be enabled twice");
                return;
            }

            _isActive = true;
            _eventLoop.InvokeEnable();
        }

        public void Disable()
        {
            if (_isActive == false)
            {
                Debug.LogError("Enemy can't be disabled twice");
                return;
            }

            _isActive = false;
            _eventLoop.InvokeDisable();
        }
        
        private void OnDied()
        {
            _returnToPool?.Invoke(this);
        }
    }
}