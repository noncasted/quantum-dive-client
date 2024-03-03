using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Common;

namespace GamePlay.Player.Entity.Components.CameraFollow.Common
{
    public class CameraFollowRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "CameraFollow";

        public const string ComponentName = PlayerEntityPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
        
        public const string ConfigName = PlayerEntityPrefixes.Config + Name;
        public const string ConfigPath = Root + "/Config";
    }
}