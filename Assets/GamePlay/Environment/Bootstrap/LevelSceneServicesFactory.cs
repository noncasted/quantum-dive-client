using Internal.Scopes.Abstract.Containers;

using Cysharp.Threading.Tasks;
using GamePlay.Player.Factory.SpawnPoints;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;

namespace GamePlay.Environment.Bootstrap
{
    [DisallowMultipleComponent]
    public class LevelSceneServicesFactory : MonoBehaviour, ILevelSceneServicesFactory
    {
        [SerializeField] private PlayerSpawnPoints _playerSpawnPoints;
        
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            _playerSpawnPoints.Register(services);
        }
    }
}