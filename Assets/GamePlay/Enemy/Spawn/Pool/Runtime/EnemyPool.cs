﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using GamePlay.Enemy.Entity.Common.Definition.Root;
using GamePlay.Enemy.Services.Mappers.Definitions.Abstract;
using GamePlay.Enemy.Spawn.Pool.Abstract;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.System.Network.Objects.Factories.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Ragon.Client;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Enemy.Spawn.Pool.Runtime
{
    public class EnemyPool : IEnemyPool
    {
        public EnemyPool(
            GamePlayScope scope,
            Scene targetScene,
            IEntityScopeLoader entityFactory,
            IDynamicEntityFactory dynamicEntityFactory,
            IEnemyDefinitionMapper definitionMapper)
        {
            _scope = scope;
            _targetScene = targetScene;
            _entityFactory = entityFactory;
            _dynamicEntityFactory = dynamicEntityFactory;
            _definitionMapper = definitionMapper;
        }

        private readonly GamePlayScope _scope;
        private readonly Scene _targetScene;
        private readonly IEntityScopeLoader _entityFactory;
        private readonly IDynamicEntityFactory _dynamicEntityFactory;

        private readonly IEnemyDefinitionMapper _definitionMapper;

        private readonly Dictionary<IEnemyDefinition, LocalEnemyObjectProvider> _localProviders = new();
        private readonly Dictionary<IEnemyDefinition, RemoteEnemyObjectProvider> _remoteProviders = new();

        public async UniTask Preload()
        {
            foreach (var definition in _definitionMapper.Definitions)
            {
                var rootObject = CreateParent(definition.Identification.Name);
                var localParent = CreateParent("Local", rootObject);
                var remoteParent = CreateParent("Remote", rootObject);

                var localProvider = new LocalEnemyObjectProvider(
                    localParent,
                    definition.Configuration.Local,
                    _entityFactory,
                    _scope);

                var remoteProvider = new RemoteEnemyObjectProvider(
                    remoteParent,
                    definition.Configuration.Remote,
                    _entityFactory,
                    _scope);

                _localProviders.Add(definition, localProvider);
                _remoteProviders.Add(definition, remoteProvider);
            }
        }

        public async UniTask<ILocalEnemyRoot> GetLocal(
            IEnemyDefinition definition,
            Vector2 position,
            RagonEntity entity)
        {
            var provider = _localProviders[definition];
            var root = await provider.GetOrCreate(position, entity);
            return root;
        }

        public async UniTask<IRemoteEnemyRoot> GetRemote(IEnemyDefinition definition, RagonEntity entity)
        {
            var provider = _remoteProviders[definition];
            var root = await provider.GetOrCreate(entity);
            return root;
        }

        private Transform CreateParent(string objectName)
        {
            var parent = CreateParent(objectName, null);
            SceneManager.MoveGameObjectToScene(parent.gameObject, _targetScene);
            return parent;
        }

        private Transform CreateParent(string objectName, Transform parent)
        {
            var root = new GameObject(objectName)
            {
                transform =
                {
                    position = Vector3.zero,
                    parent = parent
                }
            };

            return root.transform;
        }
    }
}