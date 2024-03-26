using GamePlay.Enemy.Entity.States.Damaged.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamagedRoutes.LocalName,
        menuName = EnemyDamagedRoutes.LocalPath)]
    public class LocalDamagedFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private DamagedPushConfig _pushConfig;
        [SerializeField] private DamagedDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalDamaged>()
                .WithParameter<IPushConfig>(_pushConfig)
                .WithParameter(_definition)
                .As<IDamaged>()
                .AsCallbackListener();
        }
    }
}