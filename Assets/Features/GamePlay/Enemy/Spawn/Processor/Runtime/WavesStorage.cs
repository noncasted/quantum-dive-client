using System.Collections.Generic;
using GamePlay.Enemies.Spawn.Processor.Common;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Processor.Runtime
{
    [CreateAssetMenu(fileName = WaveProcessorRoutes.StorageName,
        menuName = WaveProcessorRoutes.StoragePath)]
    public class WavesStorage : ScriptableObject
    {
        [SerializeField] private EnemyWave[] _waves;

        public IReadOnlyList<EnemyWave> Waves => _waves;
    }
}