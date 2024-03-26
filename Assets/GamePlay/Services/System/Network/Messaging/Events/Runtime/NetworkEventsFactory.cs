using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.Events.Common;
using GamePlay.Services.System.Network.Messaging.Events.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Messaging.Events.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkEventsRoutes.ServiceName, menuName = NetworkEventsRoutes.ServicePath)]
    public class NetworkEventsFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<NetworkEvents>()
                .As<INetworkEvents>()
                .AsCallbackListener();

            services.Register<NetworkEventsDistributor>()
                .As<INetworkEventsDistributor>();
        }
    }
}