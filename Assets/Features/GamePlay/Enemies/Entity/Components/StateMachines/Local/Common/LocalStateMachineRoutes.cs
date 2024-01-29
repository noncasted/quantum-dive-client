using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Common
{
    public class LocalStateMachineRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "StateMachine_Local";
        public const string ComponentPath = EnemyAssetsPaths.System + "StateMachine/Local/Component";
        
        public const string LogsName = EnemyAssetsPrefixes.Logs + "StateMachine_Local";
        public const string LogsPath = EnemyAssetsPaths.System + "StateMachine/Local/Logs";
    }
}