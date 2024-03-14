using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Services.Updater.Abstract;
using GamePlay.Enemy.Updater.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Updater.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyUpdaterRoutes.ServiceName,
        menuName = EnemyUpdaterRoutes.ServicePath)]
    public class EnemyUpdaterFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private EnemyUpdaterRatesConfig _config;
        
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<EnemyUpdater>()
                .WithParameter<IRatesConfig>(_config)
                .As<IEnemyUpdater>()
                .AsCallbackListener();
        }
    }
}