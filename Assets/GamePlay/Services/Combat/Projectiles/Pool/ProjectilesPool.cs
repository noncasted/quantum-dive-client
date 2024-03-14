using System.Collections.Generic;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using GamePlay.Combat.Projectiles.Entity.Views.Facade;
using Internal.Scopes.Abstract.Containers;
using GamePlay.Combat.Projectiles.Registry.Definition;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Combat.Projectiles.Pool
{
    public class ProjectilesPool : IScopeAwakeListener, IScopeDisableListener, IProjectilesPool
    {
        private readonly List<IObjectsPool> _pools = new();
        private readonly Dictionary<IProjectileDefinition, IObjectProvider<IProjectileView>> _providers = new();

        public void OnAwake()
        {
            foreach (var pool in _pools)
                pool.Preload();
        }

        public void OnDisabled()
        {
            foreach (var pool in _pools)
                pool.Unload();
        }

        public void CreatePools(
            IServiceCollection services,
            Scene targetScene,
            IReadOnlyList<IProjectileDefinition> definitions)
        {
            foreach (var definition in definitions)
            {
                var parent = CreateParent(definition.PoolEntry.Name, targetScene);
                var provider = definition.PoolEntry.Create(services, parent);
                _pools.Add(provider);
                _providers.Add(definition, provider.GetProvider<IProjectileView>());
            }
        }

        public IProjectileView Get(IProjectileDefinition definition, Vector3 position)
        {
            return _providers[definition].Get(position);
        }

        private Transform CreateParent(string assetName, Scene targetScene)
        {
            var root = new GameObject($"{assetName} objects")
            {
                transform =
                {
                    position = Vector3.zero
                }
            };

            SceneManager.MoveGameObjectToScene(root, targetScene);

            return root.transform;
        }
    }
}