using GamePlay.Enemy.Entity.Components.StateMachines.Local.Common;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
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

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalStateMachineLogger>()
                .WithParameter(_logSettings);

            services.Register<LocalLocalStateMachine>()
                .As<ILocalStateMachine>();
        }
    }
}