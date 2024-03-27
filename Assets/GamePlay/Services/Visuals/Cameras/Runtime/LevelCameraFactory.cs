using Cysharp.Threading.Tasks;
using GamePlay.Services.Cameras.Abstract;
using GamePlay.Services.Cameras.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Cameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.ServiceName,
        menuName = LevelCameraRoutes.ServicePath)]
    public class LevelCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraView _prefab;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var view = Instantiate(_prefab);
            view.name = "LevelCamera";

            services.Register<LevelCamera>()
                .WithParameter(view)
                .As<ILevelCamera>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(view);
        }
    }
}