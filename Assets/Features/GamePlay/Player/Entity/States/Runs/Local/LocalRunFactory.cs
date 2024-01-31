using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.States.Runs.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RunRoutes.LocalName,
        menuName = RunRoutes.LocalPath)]
    public class LocalRunFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RunAnimationFactory _runAnimation;
        [SerializeField] [Indent] private RunLogSettings _logSettings;
        [SerializeField] [Indent] private RunConfigAsset _config;
        [SerializeField] [Indent] private RunDefinition _definition;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RunLogger>()
                .WithParameter(_logSettings);

            services.Register<RunConfig>()
                .WithParameter(_config)
                .As<IRunConfig>();

            var animation = _runAnimation.Create();

            services.Register<RunInput>()
                .As<IRunInput>()
                .AsCallbackListener();

            services.Register<LocalRun>()
                .WithParameter(_definition)
                .WithParameter(animation)
                .AsCallbackListener();
        }
    }
}