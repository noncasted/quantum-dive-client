using GamePlay.Enemy.Entity.Components.DamageProcessors.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.DamageProcessors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamageProcessorRoutes.ComponentName,
        menuName = EnemyDamageProcessorRoutes.ComponentPath)]
    public class DamageProcessorFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<DamageProcessor>()
                .AsCallbackListener();
        }
    }
}