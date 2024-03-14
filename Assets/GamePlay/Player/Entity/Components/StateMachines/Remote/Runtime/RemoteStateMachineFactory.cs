using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Common;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteStateMachineRoutes.ServiceName,
        menuName = RemoteStateMachineRoutes.ServicePath)]
    public class RemoteStateMachineFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RemoteStateMachineLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
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