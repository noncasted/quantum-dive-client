using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Common
{
    public class ProjectileStarterRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name + "/";
        private const string _name = "ProjectileStarter";

        public const string ComponentName = BowAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "Component";
        
        public const string ConfigName = BowAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "Config";
    }
}