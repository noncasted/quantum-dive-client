using Common.Architecture.Container.Abstract;
using GamePlay.Common.SceneBootstrappers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Services.Factory.SpawnPoints
{
    public class PlayerSpawnPoints : SceneComponentRegister, ISpawnPoints
    {
        [SerializeField] private Transform _spawnPoint;

        public Vector2 GetSpawnPosition()
        {
            return _spawnPoint.position;
        }

        public override void Register(IServiceCollection services)
        {
            services.RegisterComponent(this)
                .As<ISpawnPoints>();
        }
    }
}