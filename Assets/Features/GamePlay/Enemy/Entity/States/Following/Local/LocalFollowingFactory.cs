using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.States.Following.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Following.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFollowingRoutes.LocalName,
        menuName = EnemyFollowingRoutes.LocalPath)]
    public class LocalFollowingFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private FollowingAnimationFactory _animation;
        [SerializeField] private FollowingDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _animation.Create();
            
            services.Register<LocalFollowing>()
                .As<IFollowing>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
            
            services.Register<FollowingTransition>()
                .WithParameter(_definition)
                .As<IFollowingTransition>();
        }
    }
}