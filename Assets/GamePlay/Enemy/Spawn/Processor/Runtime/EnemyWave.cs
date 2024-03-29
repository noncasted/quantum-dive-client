﻿using System.Collections.Generic;
using System.Linq;
using GamePlay.Enemy.Entity.Common.Definition.Asset;
using GamePlay.Enemy.Spawn.Processor.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Processor.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = WaveProcessorRoutes.WaveName,
        menuName = WaveProcessorRoutes.WavePath)]
    public class EnemyWave : ScriptableObject
    {
       [SerializeField] [Min(1)] private int _amount;
        
        public IReadOnlyList<EnemyDefinition> GetEnemies()
        {
            var enemies = new List<EnemyDefinition>();

            var entries = new List<EnemyEntry>();

            // foreach (var (type, value) in _values)
            //     entries.Add(new EnemyEntry(type, value));

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