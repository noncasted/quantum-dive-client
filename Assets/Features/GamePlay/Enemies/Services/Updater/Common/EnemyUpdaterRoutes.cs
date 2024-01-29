using GamePlay.Enemies.Services.Paths;

namespace GamePlay.Enemies.Services.Updater.Common
{
    public class EnemyUpdaterRoutes
    {
        public const string ServiceName = EnemyServicesAssetsPrefixes.Service + "Updater";
        public const string ServicePath = EnemyServicesAssetsPaths.Root + "Updater/Service";
        
        public const string ConfigName = EnemyServicesAssetsPrefixes.Config + "Updater";
        public const string ConfigPath = EnemyServicesAssetsPaths.Root + "Updater/Config";
    }
}