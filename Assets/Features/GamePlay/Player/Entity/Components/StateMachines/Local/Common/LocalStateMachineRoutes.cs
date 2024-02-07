using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Common
{
    public class LocalStateMachineRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "StateMachine";

        public const string ComponentName = PlayerEntityPrefixes.Component + "StateMachine_Local";
        public const string ComponentPath = Root + "/Local/Component";

        public const string LogsName = PlayerEntityPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Local/Logs";
    }
}