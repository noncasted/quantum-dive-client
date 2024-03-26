using GamePlay.Enemy.Entity.States.Following.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Following.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFollowingRoutes.RemoteName,
        menuName = EnemyFollowingRoutes.RemotePath)]
    public class RemoteFollowingFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private FollowingDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteFollowing>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}