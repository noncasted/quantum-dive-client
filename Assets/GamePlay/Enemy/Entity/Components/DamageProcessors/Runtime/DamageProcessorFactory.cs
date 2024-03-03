using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Components.DamageProcessors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.DamageProcessors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamageProcessorRoutes.ComponentName,
        menuName = EnemyDamageProcessorRoutes.ComponentPath)]
    public class DamageProcessorFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<DamageProcessor>()
                .AsCallbackListener();
        }
    }
}