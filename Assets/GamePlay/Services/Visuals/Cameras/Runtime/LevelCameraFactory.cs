using Cysharp.Threading.Tasks;
using GamePlay.Cameras.Abstract;
using GamePlay.Cameras.Common;
using GamePlay.Cameras.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Cameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.ServiceName,
        menuName = LevelCameraRoutes.ServicePath)]
    public class LevelCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private LevelCameraView _prefab;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
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