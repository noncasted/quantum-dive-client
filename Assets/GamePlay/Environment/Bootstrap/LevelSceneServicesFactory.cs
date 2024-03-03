using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Factory.SpawnPoints;
using UnityEngine;

namespace GamePlay.Environment.Bootstrap
{
    [DisallowMultipleComponent]
    public class LevelSceneServicesFactory : MonoBehaviour, ILevelSceneServicesFactory
    {
        [SerializeField] private PlayerSpawnPoints _playerSpawnPoints;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            _playerSpawnPoints.Register(services);
        }
    }
}