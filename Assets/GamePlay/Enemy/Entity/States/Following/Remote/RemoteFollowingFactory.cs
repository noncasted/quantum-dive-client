using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.States.Following.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Following.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFollowingRoutes.RemoteName,
        menuName = EnemyFollowingRoutes.RemotePath)]
    public class RemoteFollowingFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private FollowingAnimationFactory _animation;
        [SerializeField] private FollowingDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.Create();
            
            services.Register<RemoteFollowing>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}