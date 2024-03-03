using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<LevelLoopLogger>()
                .WithParameter(_logSettings);

            services.Register<LevelLoop>()
                .AsCallbackListener();
        }
    }
}