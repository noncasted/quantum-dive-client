using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Following.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Following.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFollowingRoutes.RemoteName,
        menuName = EnemyFollowingRoutes.RemotePath)]
    public class RemoteFollowingFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private FollowingAnimationFactory _animation;
        [SerializeField] private FollowingDefinition _definition;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();
            
            services.Register<RemoteFollowing>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}