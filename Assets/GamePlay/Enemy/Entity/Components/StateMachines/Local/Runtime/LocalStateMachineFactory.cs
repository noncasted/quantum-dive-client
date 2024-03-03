using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Common;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Local.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalStateMachineRoutes.ComponentName,
        menuName = LocalStateMachineRoutes.ComponentPath)]
    public class LocalStateMachineFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private LocalStateMachineLogSettings _logSettings;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalStateMachineLogger>()
                .WithParameter(_logSettings);

            services.Register<LocalLocalStateMachine>()
                .As<ILocalStateMachine>();
        }
    }
}