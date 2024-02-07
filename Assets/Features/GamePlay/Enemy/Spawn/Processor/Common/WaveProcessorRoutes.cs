using GamePlay.Enemy.Spawn.Common;

namespace GamePlay.Enemy.Spawn.Processor.Common
{
    public class WaveProcessorRoutes
    {
        public const string WaveName = "EnemyWave";
        public const string WavePath = EnemySpawnRoutes.Root + "Wave";
        
        public const string StorageName = EnemySpawnPrefixes.Service + "WavesStorage";
        public const string StoragePath = EnemySpawnRoutes.Root + "WavesStorage";
    }
}