using GamePlay.Common.Paths;

namespace GamePlay.Projectiles.Common
{
    public static class ProjectilesRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Projectiles/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Projectiles";

        public const string CollisionConfigPath = _paths + "CollisionDetectionConfig";
        public const string CollisionConfigName = "CollisionDetectionConfig";
        
        public const string SortingConfigPath = _paths + "SortingConfig";
        public const string SortingConfigName = "ProjectileSortingConfig";

        public const string LogsPath = _paths + "Logs";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "Projectiles";
        
        public const string DefinitionPath = _paths + "Definition";
        public const string DefinitionName = "Projectile_";
        
        public const string DefinitionsRegistryPath = _paths + "DefinitionsRegistry";
        public const string DefinitionsRegistryName = "ProjectilesDefinitionsRegistry";
    }
}