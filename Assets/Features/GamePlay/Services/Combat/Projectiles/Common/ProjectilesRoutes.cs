using GamePlay.Common.Routes;

namespace GamePlay.Combat.Projectiles.Common
{
    public static class ProjectilesRoutes
    {
        private const string Root = GamePlayServicesRoutes.Root + "Projectiles/";

        public const string ServicePath = Root + "Service";
        public const string ServiceName = GamePlayServicesPrefixes.Service + "Projectiles";

        public const string CollisionConfigPath = Root + "CollisionDetectionConfig";
        public const string CollisionConfigName = "CollisionDetectionConfig";
        
        public const string SortingConfigPath = Root + "SortingConfig";
        public const string SortingConfigName = "ProjectileSortingConfig";

        public const string LogsPath = Root + "Logs";
        public const string LogsName = GamePlayServicesPrefixes.Logs + "Projectiles";
        
        public const string DefinitionPath = Root + "Definition";
        public const string DefinitionName = "Projectile_";
        
        public const string DefinitionsRegistryPath = Root + "DefinitionsRegistry";
        public const string DefinitionsRegistryName = "ProjectilesDefinitionsRegistry";
    }
}