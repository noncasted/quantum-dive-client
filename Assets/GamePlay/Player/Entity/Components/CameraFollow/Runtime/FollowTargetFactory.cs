using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.CameraFollow.Abstract;
using GamePlay.Player.Entity.Components.CameraFollow.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.CameraFollow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CameraFollowRoutes.ComponentName, menuName = CameraFollowRoutes.ComponentPath)]
    public class FollowTargetFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private FollowTargetConfig _config;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<FollowTarget>()
                .WithParameter(_config)
                .As<IPlayerCameraFollowTarget>();
        }
    }
}