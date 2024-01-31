using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Following.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Following.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFollowingRoutes.LocalName,
        menuName = EnemyFollowingRoutes.LocalPath)]
    public class LocalFollowingFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private FollowingAnimationFactory _animation;
        [SerializeField] private FollowingDefinition _definition;
        
        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
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