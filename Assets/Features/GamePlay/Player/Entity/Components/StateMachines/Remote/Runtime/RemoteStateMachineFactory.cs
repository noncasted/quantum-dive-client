using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Common;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Player.Entity.Setup.Abstract;
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
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
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