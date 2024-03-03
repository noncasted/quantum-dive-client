using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Respawns.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Respawns.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RespawnRoutes.RemoteName,
        menuName = RespawnRoutes.RemotePath)]
    public class RemoteRespawnFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _animation;
        [SerializeField] [Indent] private RespawnDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _animation.CreateAnimation();
            
            services.Register<PlayerRemoteRespawn>()
                .WithParameter(_definition)
                .WithParameter(animation)
                .AsCallbackListener();
        }
    }
}