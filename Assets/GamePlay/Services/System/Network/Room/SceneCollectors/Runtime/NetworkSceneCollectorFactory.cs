using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using GamePlay.System.Network.Room.SceneCollectors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.System.Network.Room.SceneCollectors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneCollectorRoutes.ServiceName,
        menuName = SceneCollectorRoutes.ServicePath)]
    public class NetworkSceneCollectorFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<NetworkSceneCollector>()
                .As<IGameSceneCollector>()
                .AsCallbackListener();
        }
    }
}