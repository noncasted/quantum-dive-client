using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Idle.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Idle.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyIdleRoutes.RemoteName,
        menuName = EnemyIdleRoutes.RemotePath)]
    public class RemoteIdleFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private IdleAnimationFactory _animation;
        [SerializeField] private IdleDefinition _definition;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _animation.Create();
            
            services.Register<RemoteIdle>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}