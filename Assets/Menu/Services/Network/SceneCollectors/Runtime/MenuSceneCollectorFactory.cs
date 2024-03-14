using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Menu.Network.SceneCollectors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Network.SceneCollectors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneCollectorRoutes.ServiceName,
        menuName = SceneCollectorRoutes.ServicePath)]
    public class MenuSceneCollectorFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<MenuSceneCollector>()
                .As<IMenuSceneCollector>()
                .AsCallbackListener();
        }
    }
}