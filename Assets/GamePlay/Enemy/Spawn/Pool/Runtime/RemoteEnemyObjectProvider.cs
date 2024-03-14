using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Entities;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Config;
using GamePlay.Enemy.Entity.Common.Definition.Root;
using Ragon.Client;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Enemy.Spawn.Pool.Runtime
{
    public class RemoteEnemyObjectProvider
    {
        public RemoteEnemyObjectProvider(
            Transform parent,
            IRemoteEnemyConfig config,
            IEntityScopeLoader entityFactory,
            LifetimeScope parentScope)
        {
            _parent = parent;
            _config = config;
            _entityFactory = entityFactory;
            _parentScope = parentScope;
        }

        private readonly Transform _parent;
        private readonly IRemoteEnemyConfig _config;
        private readonly IEntityScopeLoader _entityFactory;
        private readonly LifetimeScope _parentScope;

        private readonly List<IRemoteEnemyRoot> _pooled = new();

        public async UniTask<IRemoteEnemyRoot> GetOrCreate(RagonEntity entity)
        {
            var payload = entity.GetAttachPayload<EnemySpawnPayload>();

            if (_pooled.Count != 0)
            {
                var pooledRoot = _pooled[0];
                await pooledRoot.Enable(entity, payload.Position);
                _pooled.RemoveAt(0);

                return pooledRoot;
            }

            var view = Object.Instantiate(_config.Prefab, Vector2.zero, Quaternion.identity, _parent);
            var root = await _entityFactory.Load<IRemoteEnemyRoot>(_parentScope, view, _config);

            await root.Callbacks.RunConstruct();
            await root.Enable(entity, payload.Position);

            return root;
        }

        public async UniTask Return(IRemoteEnemyRoot root)
        {
            await root.Disable();
            _pooled.Add(root);
        }
    }
}