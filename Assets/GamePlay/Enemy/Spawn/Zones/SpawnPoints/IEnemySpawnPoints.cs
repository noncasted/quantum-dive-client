    using UnityEngine;

    namespace GamePlay.Enemy.Spawn.Zones.SpawnPoints
    {
        public interface IEnemySpawnPoints
        {
            void ClearProgress();

            Vector2 GetRandom();
        }
    }
