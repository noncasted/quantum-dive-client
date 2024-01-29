using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
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
        [SerializeField] [Indent] private RespawnAnimationFactory _animation;
        [SerializeField] [Indent] private RespawnDefinition _definition;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();
            
            services.Register<PlayerRemoteRespawn>()
                .WithParameter(_definition)
                .WithParameter(animation)
                .AsCallbackListener();
        }
    }
}