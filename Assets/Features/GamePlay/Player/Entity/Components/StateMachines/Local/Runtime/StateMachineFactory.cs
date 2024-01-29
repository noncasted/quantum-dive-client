using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Common;
using GamePlay.Player.Entity.Components.StateMachines.Local.Logs;
using GamePlay.Player.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalStateMachineRoutes.ComponentName,
        menuName = LocalStateMachineRoutes.ComponentPath)]
    public class StateMachineFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private LocalStateMachineLogSettings _logSettings;

        public void Create(IServiceCollection services, ICallbackRegister callbackRegister)
        {
            services.Register<LocalStateMachineLogger>()
                .WithParameter(_logSettings);

            services.Register<StateMachine>()
                .As<ILocalStateMachine>();
        }
    }
}