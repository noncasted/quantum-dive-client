using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Common
{
    public class LocalStateMachineRoutes
    {
        private const string _root = PlayerAssetsPaths.System + _name;
        private const string _name = "StateMachine";

        public const string ComponentName = PlayerAssetsPrefixes.Component + "StateMachine_Local";
        public const string ComponentPath = _root + "/Local/Component";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Local/Logs";

        public const string StateDefinitionRegistryName = PlayerAssetsPrefixes.Component + "StateDefinitionRegistry";
        public const string StateDefinitionRegistryPath = _root + "/StateDefinitionRegistry";
    }
}