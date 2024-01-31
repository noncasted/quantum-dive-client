using Features.GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Common
{
    public class LocalStateMachineRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "StateMachine";

        public const string ComponentName = PlayerAssetsPrefixes.Component + "StateMachine_Local";
        public const string ComponentPath = Root + "/Local/Component";

        public const string LogsName = PlayerAssetsPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Local/Logs";
    }
}