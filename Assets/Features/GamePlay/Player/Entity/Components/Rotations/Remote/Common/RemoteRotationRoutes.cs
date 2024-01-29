using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Common
{
    public class RemoteRotationRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + "Rotation/Remote";
        private const string _name = "Rotation_Remote";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "/Component";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
    }
}