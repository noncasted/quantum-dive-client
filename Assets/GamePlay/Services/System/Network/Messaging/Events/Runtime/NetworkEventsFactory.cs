using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using GamePlay.System.Network.Messaging.Events.Common;
using GamePlay.System.Network.Messaging.Events.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.System.Network.Messaging.Events.Runtime
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