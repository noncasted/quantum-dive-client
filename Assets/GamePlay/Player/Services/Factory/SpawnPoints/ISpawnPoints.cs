using UnityEngine;

namespace GamePlay.Player.Factory.SpawnPoints
{
    public interface ISpawnPoints
    {
        Vector2 GetSpawnPosition();
    }
}