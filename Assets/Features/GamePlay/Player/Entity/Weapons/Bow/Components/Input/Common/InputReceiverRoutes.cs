using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Input.Common
{
    public class InputReceiverRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name + "/";
        private const string _name = "InputReceiver";

        public const string ComponentName = BowAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "Component";
    }
}