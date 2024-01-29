using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Components.Sorting.Common
{
    public class EnemySpriteSortingRoutes
    {
        private const string _root = EnemyAssetsPaths.System + _name + "/";
        private const string _name = "Sorting";

        public const string ComponentName = EnemyAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "Component";

        public const string ConfigName = EnemyAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "Config";
    }
}