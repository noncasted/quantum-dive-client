using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.Roll.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRollRoutes.LocalName,
        menuName = PlayerRollRoutes.LocalPath)]
    public class LocalRollFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private RollConfig _config;
        [SerializeField] private RollAnimationFactory _animation;
        [SerializeField] private RollDefinition _definition;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();

            services.Register<LocalRoll>()
                .WithParameter<IRollConfig>(_config)
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();

            services.Register<RollInput>()
                .As<IRollInput>()
                .AsCallbackListener();
        }
    }
}