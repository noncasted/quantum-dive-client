using Common.Architecture.Container.Abstract;
using Common.Tools.ObjectsPools.Runtime;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using GamePlay.Combat.Projectiles.Common;
using GamePlay.Combat.Projectiles.Entity.Views.Facade;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Registry.Definition
{
    [CreateAssetMenu(fileName = ProjectilesRoutes.DefinitionName, menuName = ProjectilesRoutes.DefinitionPath)]
    public class ProjectileDefinition : ScriptableObject, IProjectileDefinition, IPoolEntry
    {
        [SerializeField] [Min(1)] private int _startupInstances;

        [SerializeField] private ProjectileView _prefab;

        public IPoolEntry PoolEntry => this;

        public string Key => _prefab.name;
        public string Name => _prefab.name;
        
        public IObjectsPool Create(IServiceCollection services, Transform parent)
        {
            var factory = new ProjectileObjectFactory(_prefab, parent);
            var provider = new ObjectProvider<ProjectileView>(factory, _startupInstances, parent);

            return provider;
        }
    }
}