    using UnityEngine;

    namespace GamePlay.Enemies.Spawn.Zones.SpawnPoints
    {
        public interface IEnemySpawnPoints
        {
            void ClearProgress();

            Vector2 GetRandom();
        }
    }
