using GamePlay.Player.Entity.Components.CameraFollow.Abstract;
using GamePlay.Player.Entity.Components.CameraFollow.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.CameraFollow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CameraFollowRoutes.ComponentName, menuName = CameraFollowRoutes.ComponentPath)]
    public class FollowTargetFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private FollowTargetConfig _config;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<FollowTarget>()
                .WithParameter(_config)
                .As<IPlayerCameraFollowTarget>();
        }
    }
}