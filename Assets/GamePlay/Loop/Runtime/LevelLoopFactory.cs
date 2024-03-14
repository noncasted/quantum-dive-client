using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using GamePlay.Loop.Common;
using GamePlay.Loop.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelLoopRoutes.ServiceName,
        menuName = LevelLoopRoutes.ServicePath)]
    public class LevelLoopFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LevelLoopLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<LevelLoopLogger>()
                .WithParameter(_logSettings);

            services.Register<LevelLoop>()
                .AsCallbackListener();
        }
    }
}