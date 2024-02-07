﻿using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateSelectors;
using GamePlay.Enemy.Entity.Definition.Root;
using GamePlay.Enemy.Entity.Network.EntityHandler.Runtime;
using GamePlay.Enemy.Entity.States.Respawn.Local;
using GamePlay.Enemy.Entity.Views.GameObjects;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Setup.Root.Local
{
    public class LocalEnemyRoot : ILocalEnemyRoot
    {
        public LocalEnemyRoot(
            IEntityProvider entityProvider,
            IStateSelector stateSelector,
            IRespawn respawn,
            IEntityCallbacks callbacks,
            IEnemyTransform transform,
            IEnemyGameObject gameObject)
        {
            _entityProvider = entityProvider;
            _stateSelector = stateSelector;
            _respawn = respawn;
            _callbacks = callbacks;
            _transform = transform;
            _gameObject = gameObject;
        }

        private readonly IEntityProvider _entityProvider;
        private readonly IStateSelector _stateSelector;
        private readonly IRespawn _respawn;
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

        public async UniTask Respawn()
        {
            await _respawn.Enter();
            
            _stateSelector.Start();
        }
    }
}