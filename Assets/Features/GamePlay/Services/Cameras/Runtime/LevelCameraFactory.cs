using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Cameras.Common;
using GamePlay.Cameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Cameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.ServiceName,
        menuName = LevelCameraRoutes.ServicePath)]
    public class LevelCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraConfigAsset _config;
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private LevelCamera _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var levelCamera = Instantiate(_prefab);
            levelCamera.name = "LevelCamera";

            services.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            services.Register<LevelCameraConfig>()
                .WithParameter(_config)
                .As<ILevelCameraConfig>();

            services.RegisterComponent(levelCamera)
                .As<ILevelCamera>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(levelCamera);
        }
    }
}