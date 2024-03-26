using GamePlay.Enemy.Entity.States.Following.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Following.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFollowingRoutes.LocalName,
        menuName = EnemyFollowingRoutes.LocalPath)]
    public class LocalFollowingFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private FollowingDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalFollowing>()
                .As<IFollowing>()
                .WithParameter(_definition)
                .AsCallbackListener();
            
            services.Register<FollowingTransition>()
                .WithParameter(_definition)
                .As<IFollowingTransition>();
        }
    }
}