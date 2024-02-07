using System.Collections.Generic;
using System.Linq;
using GamePlay.Enemies.Entity.Definition.Asset;
using GamePlay.Enemies.Spawn.Processor.Common;
using GamePlay.Enemies.Spawn.Processor.Definition.Probability.Runtime;
using GamePlay.Enemies.Spawn.Processor.Definition.ToggleButtons.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Processor.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = WaveProcessorRoutes.WaveName,
        menuName = WaveProcessorRoutes.WavePath)]
    public class EnemyWave : ScriptableObject
    {
        [SerializeField] [EnemyToggle] private EnemyTypesDictionary _switches = new();
        [SerializeField] [EnemyProbability] private EnemyProbabilityDictionary _values = new();
        
        [SerializeField] [Min(1)] private int _amount;
        
        public IReadOnlyList<EnemyDefinition> GetEnemies()
        {
            var enemies = new List<EnemyDefinition>();

            var entries = new List<EnemyEntry>();

            foreach (var (type, value) in _values)
                entries.Add(new EnemyEntry(type, value));

            entries = entries.OrderBy(t => t.Density).ToList();

            var spawnAmount = _amount;

            foreach (var entry in entries)
            {
                var count = Mathf.CeilToInt(_amount * entry.Density);

                if (count > spawnAmount)
                    count = spawnAmount;

                spawnAmount -= count;

                if (count <= 0)
                    continue;

                for (var i = 0; i < count; i++)
                    enemies.Add(entry.Definition);
            }

            return enemies;
        }
    }
}