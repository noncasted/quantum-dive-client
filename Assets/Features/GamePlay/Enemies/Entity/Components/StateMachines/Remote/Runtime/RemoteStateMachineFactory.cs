using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Common;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Logs;
using Common.Architecture.Entities.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteStateMachineRoutes.ComponentName,
        menuName = RemoteStateMachineRoutes.ComponentPath)]
    public class RemoteStateMachineFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private RemoteStateMachineLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteStateMachineLogger>()
                .WithParameter(_logSettings);
            
            services.Register<RemoteStateMachine>()
                .As<IRemoteStateMachine>()
                .As<IStateMachineSync>()
                .AsSelf();
        }
    }
}