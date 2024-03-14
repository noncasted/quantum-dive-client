using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Common.Tools.UniversalAnimators.Abstract;
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
        [SerializeField] private BaseAnimationData _animation;
        [SerializeField] private RollDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.CreateAnimation();

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