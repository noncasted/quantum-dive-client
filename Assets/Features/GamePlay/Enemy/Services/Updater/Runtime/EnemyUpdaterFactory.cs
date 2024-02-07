using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Updater.Common;
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
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemyUpdater>()
                .WithParameter<IRatesConfig>(_config)
                .As<IEnemyUpdater>()
                .AsCallbackListener();
        }
    }
}