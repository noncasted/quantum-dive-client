using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Idle.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Idle.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyIdleRoutes.LocalName,
        menuName = EnemyIdleRoutes.LocalPath)]
    public class LocalIdleFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private IdleAnimationFactory _animation;
        [SerializeField] private IdleDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
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