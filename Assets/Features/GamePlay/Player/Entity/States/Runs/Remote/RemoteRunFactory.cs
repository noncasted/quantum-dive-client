using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Runs.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RunRoutes.RemoteName,
        menuName = RunRoutes.RemotePath)]
    public class RemoteRunFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RunAnimationFactory _runAnimation;
        [SerializeField] [Indent] private RunDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _runAnimation.Create();

            services.Register<RunInputSync>()
                .As<IRunInputSync>()
                .AsSelf();
            
            services.Register<RemoteRun>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}