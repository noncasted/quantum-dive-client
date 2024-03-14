using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.Events.Common;
using GamePlay.Network.Messaging.Events.Logs;
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
        [SerializeField] private NetworkEventsLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<NetworkEvents>()
                .As<INetworkEvents>()
                .AsCallbackListener();

            services.Register<NetworkEventsLogger>()
                .WithParameter(_logSettings);

            services.Register<NetworkEventsDistributor>()
                .As<INetworkEventsDistributor>();
        }
    }
}