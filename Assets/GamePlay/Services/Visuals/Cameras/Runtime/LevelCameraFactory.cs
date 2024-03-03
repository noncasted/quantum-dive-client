using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Visuals.Cameras.Abstract;
using GamePlay.Visuals.Cameras.Common;
using GamePlay.Visuals.Cameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Visuals.Cameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.ServiceName,
        menuName = LevelCameraRoutes.ServicePath)]
    public class LevelCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private LevelCameraView _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var view = Instantiate(_prefab);
            view.name = "LevelCamera";

            services.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            
            services.Register<LevelCamera>()
                .WithParameter(view)
                .As<ILevelCamera>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(view);
        }
    }
}