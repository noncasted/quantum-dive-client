using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Config;
using GamePlay.Enemy.Entity.Common.Definition.Root;
using GamePlay.System.Network.Objects.Factories.Runtime;
using Ragon.Client;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Enemy.Spawn.Pool.Runtime
{
    public class LocalEnemyObjectProvider
    {
        public LocalEnemyObjectProvider(
            Transform parent,
            ILocalEnemyConfig config,
            IScopedEntityFactory entityFactory,
            LifetimeScope parentScope)
        {
            _parent = parent;
            _config = config;
            _entityFactory = entityFactory;
            _parentScope = parentScope;
        }

        private readonly Transform _parent;
        private readonly ILocalEnemyConfig _config;
        private readonly IScopedEntityFactory _entityFactory;
        private readonly IDynamicEntityFactory _dynamicEntityFactory;
        private readonly LifetimeScope _parentScope;

        private readonly List<ILocalEnemyRoot> _pooled = new();

        public async UniTask<ILocalEnemyRoot> GetOrCreate(Vector2 position, RagonEntity entity)
        {
            if (_pooled.Count != 0)
            {
                var pooledRoot = _pooled[0];
                await pooledRoot.Enable(entity, position);

                return pooledRoot;
            }

            var view = Object.Instantiate(_config.Prefab, position, Quaternion.identity, _parent);
            var root = await _entityFactory.Create<ILocalEnemyRoot>(_parentScope, view, _config);

            await root.Callbacks.RunConstruct();
            await root.Enable(entity, position);

            return root;
        }

        public async UniTask Return(ILocalEnemyRoot root)
        {
            await root.Disable();
            _pooled.Add(root);
        }
    }
}