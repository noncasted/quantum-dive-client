using GamePlay.Enemies.Entity.Components.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Common
{
    public class LocalStateMachineRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "StateMachine_Local";
        public const string ComponentPath = EnemyComponentsRoutes.Root + "StateMachine/Local/Component";
        
        public const string LogsName = EnemyEntityPrefixes.Logs + "StateMachine_Local";
        public const string LogsPath = EnemyComponentsRoutes.Root + "StateMachine/Local/Logs";
    }
}