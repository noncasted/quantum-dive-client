using GamePlay.Player.Entity.Weapons.Sword.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Factory.Common
{
    public class SwordFactoryRoutes
    {
        private const string _root = SwordAssetsPaths.Root + _name + "/";
        private const string _name = "Factory";

        public const string ComponentName = SwordAssetsPrefixes.Config + "Factory";
        public const string ComponentPath = _root + "Factory";
    }
}