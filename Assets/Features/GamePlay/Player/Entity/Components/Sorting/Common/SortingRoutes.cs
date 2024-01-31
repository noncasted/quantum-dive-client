using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Sorting.Common
{
    public class SortingRoutes
    {
        public const string ComponentName = PlayerAssetsPrefixes.Component + "Sorting";
        public const string ComponentPath = PlayerComponentsRoutes.Root + "Sorting/Component";

        public const string ConfigName = PlayerAssetsPrefixes.Config + "SpriteSorting";
        public const string ConfigPath = PlayerComponentsRoutes.Root + "Sorting/Config";
    }
}