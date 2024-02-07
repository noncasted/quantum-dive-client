using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Spawn.Factory.Common;
using GamePlay.Enemies.Spawn.Factory.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFactoryRoutes.ServiceName,
        menuName = EnemyFactoryRoutes.ServicePath)]
    public class EnemyFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EnemyFactoryLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemyFactoryLogger>()
                .WithParameter(_logSettings);
            
            services.Register<EnemyFactory>()
                .As<IEnemyFactory>()
                .AsCallbackListener();
        }
    }
}