using GamePlay.Enemies.Services.Paths;

namespace GamePlay.Enemies.Services.Spawn.Pool.Common
{
    public class EnemyPoolRoutes
    {
        public const string PoolName = EnemyServicesAssetsPrefixes.Service + "Pool";
        public const string PoolPath = EnemyServicesAssetsPaths.Root + "Pool";
        
        public const string RegistryName = EnemyServicesAssetsPrefixes.Service + "DefinitionsRegistry";
        public const string RegistryPath = EnemyServicesAssetsPaths.Root + "DefinitionsRegistry";
    }
}