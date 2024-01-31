using Features.GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Common
{
    public class RemoteRotationRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + "Rotation/Remote";
        private const string Name = "Rotation_Remote";

        public const string ComponentName = PlayerAssetsPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";

        public const string LogsName = PlayerAssetsPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
    }
}