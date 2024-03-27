using Cysharp.Threading.Tasks;
using GamePlay.Services.Network.Room.SceneCollectors.Common;
using GamePlay.Services.System.Network.Room.SceneCollectors.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Network.Room.SceneCollectors.Runtime
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