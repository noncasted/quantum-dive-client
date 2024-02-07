using UnityEngine;

namespace GamePlay.Player.Services.Factory.SpawnPoints
{
    public interface ISpawnPoints
    {
        Vector2 GetSpawnPosition();
    }
}