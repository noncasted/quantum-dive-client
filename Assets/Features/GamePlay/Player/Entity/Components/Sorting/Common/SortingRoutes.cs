using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Common;

namespace GamePlay.Player.Entity.Components.Sorting.Common
{
    public class SortingRoutes
    {
        public const string ComponentName = PlayerEntityPrefixes.Component + "Sorting";
        public const string ComponentPath = PlayerComponentsRoutes.Root + "Sorting/Component";

        public const string ConfigName = PlayerEntityPrefixes.Config + "SpriteSorting";
        public const string ConfigPath = PlayerComponentsRoutes.Root + "Sorting/Config";
    }
}