using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.States.Idle.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Idle.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyIdleRoutes.LocalName,
        menuName = EnemyIdleRoutes.LocalPath)]
    public class LocalIdleFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private IdleAnimationFactory _animation;
        [SerializeField] private IdleDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.Create();
            
            services.Register<LocalIdle>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .As<IIdle>();

            services.Register<IdleTransition>()
                .WithParameter(_definition)
                .As<IIdleTransition>();
        }
    }
}