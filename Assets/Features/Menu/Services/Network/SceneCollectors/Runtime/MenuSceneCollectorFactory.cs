using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Services.Network.SceneCollectors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Services.Network.SceneCollectors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneCollectorRoutes.ServiceName,
        menuName = SceneCollectorRoutes.ServicePath)]
    public class MenuSceneCollectorFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MenuSceneCollector>()
                .As<IMenuSceneCollector>()
                .AsCallbackListener();
        }
    }
}