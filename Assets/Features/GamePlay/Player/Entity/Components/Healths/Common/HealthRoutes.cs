using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Common;

namespace GamePlay.Player.Entity.Components.Healths.Common
{
    public class HealthRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "Health";

        public const string ComponentName = PlayerEntityPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
    }
}