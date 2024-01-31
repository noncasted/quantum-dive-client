using Features.GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Common
{
    public class LocalRotationRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + "Rotation/Local";
        private const string Name = "Rotation_Local";

        public const string ComponentName = PlayerAssetsPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";

        public const string LogsName = PlayerAssetsPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
    }
}