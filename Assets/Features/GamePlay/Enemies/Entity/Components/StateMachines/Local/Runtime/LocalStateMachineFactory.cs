using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Common;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Logs;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalStateMachineRoutes.ComponentName,
        menuName = LocalStateMachineRoutes.ComponentPath)]
    public class LocalStateMachineFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] [Indent] private LocalStateMachineLogSettings _logSettings;

        public void Create(IServiceCollection services, ICallbackRegister callbackRegister)
        {
            services.Register<LocalStateMachineLogger>()
                .WithParameter(_logSettings);

            services.Register<LocalLocalStateMachine>()
                .As<ILocalStateMachine>();
        }
    }
}