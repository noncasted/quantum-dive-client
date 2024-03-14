using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.States.Damaged.Common;
using Internal.Scopes.Abstract.Containers;
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
        [SerializeField] private DamagedAnimationFactory _animation;
        [SerializeField] private DamagedDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.Create();
            
            services.Register<LocalDamaged>()
                .WithParameter<IPushConfig>(_pushConfig)
                .WithParameter(_definition)
                .WithParameter(animation)
                .As<IDamaged>()
                .AsCallbackListener();
        }
    }
}