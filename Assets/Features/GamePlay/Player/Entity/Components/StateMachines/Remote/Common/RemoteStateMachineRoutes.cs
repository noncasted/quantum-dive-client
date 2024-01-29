using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Common
{
    public class RemoteStateMachineRoutes
    {
        public const string ServiceName = PlayerAssetsPrefixes.Component + "StateMachine_Remote";
        public const string ServicePath = PlayerAssetsPaths.System + "/Remote/Component";
        
        public const string LogsName = PlayerAssetsPrefixes.Logs + "StateMachine_Remote";
        public const string LogsPath = PlayerAssetsPaths.System + "/Remote/Logs";
    }
}