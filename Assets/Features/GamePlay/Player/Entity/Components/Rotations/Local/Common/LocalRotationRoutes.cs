using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Common
{
    public class LocalRotationRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + "Rotation/Local";
        private const string _name = "Rotation_Local";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "/Component";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
    }
}