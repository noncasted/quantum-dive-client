using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Views.Hitboxes.Common
{
    public class HitboxRoutes
    {
        private const string _root = PlayerAssetsPaths.Views + _name;
        private const string _name = "Hitbox";

        public const string ConfigName = PlayerAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "/Config";

        public const string GizmosConfigName = PlayerAssetsPrefixes.Config + "Hitbox_Gizmos";
        public const string GizmosConfigPath = _root + "/GizmosConfig";
    }
}