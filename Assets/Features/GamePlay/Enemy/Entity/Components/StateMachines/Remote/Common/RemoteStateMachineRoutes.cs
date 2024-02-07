using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Components.Common;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Remote.Common
{
    public class RemoteStateMachineRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "StateMachine_Remote";
        public const string ComponentPath = EnemyComponentsRoutes.Root + "StateMachine/Remote/Component";
        
        public const string LogsName = EnemyEntityPrefixes.Logs + "StateMachine_Remote";
        public const string LogsPath = EnemyComponentsRoutes.Root + "StateMachine/Remote/Logs";
    }
}