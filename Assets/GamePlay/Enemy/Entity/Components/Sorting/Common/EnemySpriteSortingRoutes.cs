using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Components.Common;

namespace GamePlay.Enemy.Entity.Components.Sorting.Common
{
    public class EnemySpriteSortingRoutes
    {
        private const string _root = EnemyComponentsRoutes.Root + _name + "/";
        private const string _name = "Sorting";

        public const string ComponentName = EnemyEntityPrefixes.Component + _name;
        public const string ComponentPath = _root + "Component";

        public const string ConfigName = EnemyEntityPrefixes.Config + _name;
        public const string ConfigPath = _root + "Config";
    }
}