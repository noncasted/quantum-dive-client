using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using GamePlay.System.Network.Messaging.REST.Common;
using GamePlay.System.Network.Messaging.REST.Logs;
using GamePlay.System.Network.Messaging.REST.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.System.Network.Messaging.REST.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessengerRoutes.ServiceName, menuName = MessengerRoutes.ServicePath)]
    public class MessengerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private MessengerLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<MessengerLogger>()
                .WithParameter(_logSettings);
            
            services.Register<Messenger>()
                .As<IMessenger>()
                .AsCallbackListener();

            services.Register<MessageDistributor>()
                .As<IMessageDistributor>();
        }
    }
}