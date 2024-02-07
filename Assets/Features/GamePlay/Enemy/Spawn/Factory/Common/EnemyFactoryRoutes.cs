using GamePlay.Enemy.Spawn.Common;

namespace GamePlay.Enemies.Spawn.Factory.Common
{
    public class EnemyFactoryRoutes
    {
        public const string ServiceName = EnemySpawnPrefixes.Service + "Factory";
        public const string ServicePath = EnemySpawnRoutes.Root + "Factory/Service";
        
        public const string LogsName = EnemySpawnPrefixes.Logs + "Factory";
        public const string LogsPath = EnemySpawnRoutes.Root + "Factory/Logs";
    }
}