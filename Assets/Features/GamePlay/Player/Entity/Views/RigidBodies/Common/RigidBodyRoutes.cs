using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.Views.Common;

namespace GamePlay.Player.Entity.Views.RigidBodies.Common
{
    public class RigidBodyRoutes
    {
        private const string Root = PlayerViewsRoutes.Root + Name;
        private const string Name = "RigidBody";

        public const string LogsName = PlayerEntityPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";

        public const string GizmosConfigName = PlayerEntityPrefixes.Logs + Name;
        public const string GizmosConfigPath = Root + "/GizmosConfig";
    }
}