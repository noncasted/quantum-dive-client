using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Factory.Common
{
    public class BowFactoryRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name + "/";
        private const string _name = "Factory";

        public const string ComponentName = BowAssetsPrefixes.Config + "Factory";
        public const string ComponentPath = _root + "Factory";
    }
}