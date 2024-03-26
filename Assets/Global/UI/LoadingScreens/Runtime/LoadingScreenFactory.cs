using Common.DataTypes.Runtime.Attributes;
using Cysharp.Threading.Tasks;
using Global.UI.LoadingScreens.Abstract;
using Global.UI.LoadingScreens.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.LoadingScreens.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoadingScreenRouter.ServiceName,
        menuName = LoadingScreenRouter.ServicePath)]
    public class LoadingScreenFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [CreateSO] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var (_, loadingScreen) = await utils.SceneLoader.LoadTyped<LoadingScreen>(_scene);

            services.RegisterComponent(loadingScreen)
                .As<ILoadingScreen>();
        }
    }
}