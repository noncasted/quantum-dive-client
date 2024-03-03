using GamePlay.Enemy.Common;

namespace GamePlay.Enemy.Updater.Common
{
    public class EnemyUpdaterRoutes
    {
        public const string ServiceName = EnemyServicesPrefixes.Service + "Updater";
        public const string ServicePath = EnemyServicesRoutes.Root + "Updater/Service";
        
        public const string ConfigName = EnemyServicesPrefixes.Config + "Updater";
        public const string ConfigPath = EnemyServicesRoutes.Root + "Updater/Config";
    }
}