using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Views.Common;

namespace GamePlay.Player.Entity.Views.Hitboxes.Common
{
    public class HitboxRoutes
    {
        private const string Root = PlayerViewsRoutes.Root + Name;
        private const string Name = "Hitbox";

        public const string ConfigName = PlayerEntityPrefixes.Config + Name;
        public const string ConfigPath = Root + "/Config";

        public const string GizmosConfigName = PlayerEntityPrefixes.Config + "Hitbox_Gizmos";
        public const string GizmosConfigPath = Root + "/GizmosConfig";
    }
}