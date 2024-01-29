using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Common
{
    public class RemoteStateMachineRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "StateMachine_Remote";
        public const string ComponentPath = EnemyAssetsPaths.System + "StateMachine/Remote/Component";
        
        public const string LogsName = EnemyAssetsPrefixes.Logs + "StateMachine_Remote";
        public const string LogsPath = EnemyAssetsPaths.System + "StateMachine/Remote/Logs";
    }
}