using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.Health.Common;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.Health.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyHealthRoutes.ComponentName,
        menuName = EnemyHealthRoutes.ComponentPath)]
    public class HealthFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private HealthConfig _config;
        
        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<Health>()
                .WithParameter<IHealthConfig>(_config)
                .As<IHealth>()
                .AsSelf();
        }
    }
}