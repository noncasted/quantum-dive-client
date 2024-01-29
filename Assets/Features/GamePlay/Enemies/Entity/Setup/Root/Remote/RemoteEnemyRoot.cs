using System;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Network.EntityHandler;
using GamePlay.Enemies.Entity.Network.Properties.Runtime;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Setup.Root.Remote
{
    public class RemoteEnemyRoot : IRemoteEnemyRoot
    {
        private RemoteEnemyRoot(
            IEnemyEventLoop eventLoop,
            IEntityProvider entityProvider,
            INetworkPropertiesBinder networkPropertiesBinder,
            GameObject gameObject)
        {
            _eventLoop = eventLoop;
            _entityProvider = entityProvider;
            _networkPropertiesBinder = networkPropertiesBinder;
            _gameObject = gameObject;
        }
        
        private readonly IEnemyEventLoop _eventLoop;
        private readonly IEntityProvider _entityProvider;
        private readonly INetworkPropertiesBinder _networkPropertiesBinder;
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
        }

        public void OnAttached()
        {
            _eventLoop.InvokeEnable();
            _eventLoop.InvokeEntityAttached();
        }
        
        public void OnTaken()
        {
            _entityProvider.Detached += OnDetached;
        }

        private void OnDetached()
        {
            _returnToPool?.Invoke(this);
        }

        public void OnReturned()
        {
            _entityProvider.Detached -= OnDetached;
            _eventLoop.InvokeDisable();
        }

        public void Enable()
        {
            if (_isActive == true)
            {
                Debug.LogError("Player can't be enabled twice");
                return;
            }

            _isActive = true;
            _eventLoop.InvokeEnable();
        }

        public void Disable()
        {
            if (_isActive == false)
            {
                Debug.LogError("Player can't be disabled twice");
                return;
            }

            _isActive = false;
            _eventLoop.InvokeDisable();
        }
    }
}