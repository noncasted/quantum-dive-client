using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Environment.Common;
using UnityEngine;

namespace GamePlay.Environment.Bootstrap
{
    [CreateAssetMenu(fileName = LevelEnvironmentRoutes.MockName,
        menuName = LevelEnvironmentRoutes.MockPath)]
    public class LevelEnvironmentMockFactory : LevelEnvironmentBaseFactory
    {
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var bootstrapper = FindFirstObjectByType<SceneBootstrapper>();
            bootstrapper.Build(services, utils.Callbacks);
        }
    }
}