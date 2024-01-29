using GamePlay.Enemies.Services.Paths;

namespace GamePlay.Enemies.Spawn.Processor.Common
{
    public class WaveProcessorRoutes
    {
        public const string WaveName = "EnemyWave";
        public const string WavePath = EnemyServicesAssetsPaths.Root + "Wave";
        
        public const string StorageName = "EnemyWavesStorage";
        public const string StoragePath = EnemyServicesAssetsPaths.Root + "WavesStorage";
    }
}