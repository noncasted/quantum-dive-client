using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Zones.SpawnPoints
{
    public class EnemySpawnPoints : MonoBehaviour, IEnemySpawnPoints
    {
        [SerializeField] private Transform[] _points;

        private List<Transform> _available;

        public void ClearProgress()
        {
            foreach (var point in _points)
                _available.Add(point);
        }

        public Vector2 GetRandom()
        {
            if (_available.Count == 0)            
                ClearProgress();

            return _available[Random.Range(0, _available.Count)].position;
        }
    }
}