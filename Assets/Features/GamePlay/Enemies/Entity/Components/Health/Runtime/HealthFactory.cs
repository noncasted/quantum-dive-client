using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.Health.Common;
using Common.Architecture.Entities.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.Health.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyHealthRoutes.ComponentName,
        menuName = EnemyHealthRoutes.ComponentPath)]
    public class HealthFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private HealthConfig _config;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<Health>()
                .WithParameter<IHealthConfig>(_config)
                .As<IHealth>()
                .AsSelf();
        }
    }
}