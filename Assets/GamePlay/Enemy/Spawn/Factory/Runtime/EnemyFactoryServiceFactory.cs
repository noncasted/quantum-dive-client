using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Spawn.Factory.Common;
using GamePlay.Enemy.Spawn.Factory.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFactoryRoutes.ServiceName,
        menuName = EnemyFactoryRoutes.ServicePath)]
    public class EnemyFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EnemyFactoryLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<EnemyFactoryLogger>()
                .WithParameter(_logSettings);
            
            services.Register<EnemyFactory>()
                .As<IEnemyFactory>()
                .AsCallbackListener();
        }
    }
}