using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.Respawns.Common;
using GamePlay.Player.Entity.States.Respawns.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Respawns.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RespawnRoutes.LocalName,
        menuName = RespawnRoutes.LocalPath)]
    public class LocalRespawnFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RespawnLogSettings _logSettings;
        [SerializeField] [Indent] private RespawnAnimationFactory _animation;
        [SerializeField] [Indent] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, ICallbackRegister callbackRegister)
        {
            var animation = _animation.Create();
            
            services.Register<RespawnLogger>()
                .WithParameter(_logSettings);

            services.Register<LocalRespawn>()
                .As<IRespawn>()
                .WithParameter(_definition)
                .WithParameter(animation);
        }
    }
}