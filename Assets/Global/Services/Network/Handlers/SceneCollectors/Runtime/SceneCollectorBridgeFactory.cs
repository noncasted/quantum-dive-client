using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Global.Network.Handlers.SceneCollectors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Handlers.SceneCollectors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneCollectorBridgeRoutes.ServiceName,
        menuName = SceneCollectorBridgeRoutes.ServicePath)]
    public class SceneCollectorBridgeFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<SceneCollectorBridge>()
                .As<ISceneCollectorBridge>();
        }
    }
}