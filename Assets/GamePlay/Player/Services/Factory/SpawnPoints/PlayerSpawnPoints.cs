using Internal.Scopes.Abstract.Containers;
using UnityEngine;

namespace GamePlay.Player.Factory.SpawnPoints
{
    public class PlayerSpawnPoints : MonoBehaviour, ISpawnPoints
    {
        [SerializeField] private Transform _spawnPoint;

        public Vector2 GetSpawnPosition()
        {
            return _spawnPoint.position;
        }

        public void Register(IServiceCollection services)
        {
            services.RegisterComponent(this)
                .As<ISpawnPoints>();
        }
    }
}