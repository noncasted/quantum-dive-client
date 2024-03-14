using Internal.Scopes.Abstract.Lifetimes;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Root;
using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Enemy.Entity.Views.GameObjects;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using Internal.Scopes.Common.Entity;
using Internal.Scopes.Runtime.Lifetimes;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Root.Remote
{
    public class RemoteEnemyRoot : IRemoteEnemyRoot
    {
        private RemoteEnemyRoot(
            IEntityProvider entityProvider,
            IEntityCallbacks callbacks,
            IEnemyTransform transform,
            IEnemyGameObject gameObject)
        {
            _entityProvider = entityProvider;
            _callbacks = callbacks;
            _transform = transform;
            _gameObject = gameObject;
        }

        private readonly IEntityProvider _entityProvider;
        private readonly IEntityCallbacks _callbacks;
        private readonly IEnemyTransform _transform;
        private readonly IEnemyGameObject _gameObject;

        private bool _isActive;
        private ILifetime _lifetime;

        public IEntityCallbacks Callbacks => _callbacks;

        public async UniTask Enable(RagonEntity entity, Vector2 position)
        {
            if (_isActive == true)
            {
                Debug.LogError("Player can't be enabled twice");
                return;
            }

            _isActive = true;
            
            _entityProvider.Construct(entity);
            
            if (_lifetime != null)
                await _lifetime.Terminate();

            _lifetime = new Lifetime();
            await _callbacks.RunEnable(_lifetime);
            
            _gameObject.Enable();
            _transform.SetPosition(position);
        }

        public async UniTask Disable()
        {
            if (_isActive == false)
            {
                Debug.LogError("Player can't be disabled twice");
                return;
            }

            _isActive = false;
            _gameObject.Disable();
            _transform.SetPosition(Vector2.zero);

            await _lifetime.Terminate();
            await _callbacks.RunDisable();
        }
    }
}