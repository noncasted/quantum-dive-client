using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Views.Common;

namespace GamePlay.Player.Entity.Views.Physics.Common
{
    public class PlayerPhysicsRoutes
    {
        private const string Root = PlayerViewsRoutes.Root + Name;
        private const string Name = "RigidBody";

        public const string LogsName = PlayerEntityPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";

        public const string GizmosConfigName = PlayerEntityPrefixes.Logs + Name;
        public const string GizmosConfigPath = Root + "/GizmosConfig";
        
        public const string ConfigName = PlayerEntityPrefixes.Logs + Name;
        public const string ConfigPath = Root + "/Config";
    }
}