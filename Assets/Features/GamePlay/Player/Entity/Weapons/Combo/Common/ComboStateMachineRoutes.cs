using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Weapons.Combo.Common
{
    public class ComboStateMachineRoutes
    {
        private const string _root = PlayerAssetsPaths.System + _name;
        private const string _name = "ComboStateMachine";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "/Component";
    }
}