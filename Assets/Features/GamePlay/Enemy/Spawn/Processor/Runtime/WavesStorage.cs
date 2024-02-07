using System.Collections.Generic;
using GamePlay.Enemy.Spawn.Processor.Common;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Processor.Runtime
{
    [CreateAssetMenu(fileName = WaveProcessorRoutes.StorageName,
        menuName = WaveProcessorRoutes.StoragePath)]
    public class WavesStorage : ScriptableObject
    {
        [SerializeField] private EnemyWave[] _waves;

        public IReadOnlyList<EnemyWave> Waves => _waves;
    }
}