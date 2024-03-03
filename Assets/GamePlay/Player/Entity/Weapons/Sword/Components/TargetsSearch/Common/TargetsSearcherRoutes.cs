using GamePlay.Player.Entity.Weapons.Sword.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Common
{
    public class TargetsSearcherRoutes
    {
        private const string _root = SwordAssetsPaths.Root + _name + "/";
        private const string _name = "TargetsSearcher";

        public const string ComponentName = SwordAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + _name;
    }
}