using GamePlay.Player.Entity.Weapons.Sword.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Input.Common
{
    public class SwordInputRoutes
    {
        private const string _root = SwordAssetsPaths.Root + _name + "/";
        private const string _name = "InputReceiver";

        public const string ComponentName = SwordAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + _name;
    }
}