using Features.GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Healths.Common
{
    public class HealthRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "Health";

        public const string ComponentName = PlayerAssetsPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
    }
}