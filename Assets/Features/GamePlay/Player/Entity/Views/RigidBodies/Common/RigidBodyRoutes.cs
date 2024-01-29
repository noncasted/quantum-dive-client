using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Views.RigidBodies.Common
{
    public class RigidBodyRoutes
    {
        private const string _root = PlayerAssetsPaths.Views + _name;
        private const string _name = "RigidBody";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";

        public const string GizmosConfigName = PlayerAssetsPrefixes.Logs + _name;
        public const string GizmosConfigPath = _root + "/GizmosConfig";
    }
}