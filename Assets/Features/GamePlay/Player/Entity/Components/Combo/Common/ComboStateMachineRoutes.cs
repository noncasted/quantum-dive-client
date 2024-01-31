using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Combo.Common
{
    public class ComboStateMachineRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "ComboStateMachine";

        public const string ComponentName = PlayerAssetsPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
    }
}