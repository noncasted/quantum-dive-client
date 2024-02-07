using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.Enemies.Entity.Definition.Asset.Abstract;
using GamePlay.Enemies.Entity.Definition.Root;
using GamePlay.Enemies.Services.Spawn.Registry.Runtime;
using GamePlay.Network.Objects.Factories.Runtime;
using Ragon.Client;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Enemies.Services.Spawn.Pool.Runtime
{
    public class EnemyPool : IEnemyPool
    {
        public EnemyPool(
            LevelScope scope,
            Scene targetScene,
            IScopedEntityFactory entityFactory,
            IDynamicEntityFactory dynamicEntityFactory,
            IEnemyDefinitionsRegistry definitionsRegistry)
        {
            _scope = scope;
            _targetScene = targetScene;
            _entityFactory = entityFactory;
            _dynamicEntityFactory = dynamicEntityFactory;
            _definitionsRegistry = definitionsRegistry;
        }

        private readonly LevelScope _scope;
        private readonly Scene _targetScene;
        private readonly IScopedEntityFactory _entityFactory;
        private readonly IDynamicEntityFactory _dynamicEntityFactory;

        private readonly IEnemyDefinitionsRegistry _definitionsRegistry;

        private readonly Dictionary<IEnemyDefinition, LocalEnemyObjectProvider> _localProviders = new();
        private readonly Dictionary<IEnemyDefinition, RemoteEnemyObjectProvider> _remoteProviders = new();

        public async UniTask Preload()
        {
            foreach (var definition in _definitionsRegistry.Definitions)
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