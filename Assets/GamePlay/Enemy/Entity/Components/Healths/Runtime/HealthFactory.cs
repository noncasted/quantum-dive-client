using GamePlay.Enemy.Entity.Components.Healths.Abstract;
using GamePlay.Enemy.Entity.Components.Healths.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Healths.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyHealthRoutes.ComponentName,
        menuName = EnemyHealthRoutes.ComponentPath)]
    public class HealthFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private HealthConfig _config;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<Health>()
                .WithParameter<IHealthConfig>(_config)
                .As<IHealth>()
                .AsSelf();
        }
    }
}