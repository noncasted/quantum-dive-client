using Cysharp.Threading.Tasks;
using Global.System.MessageBrokers.Abstract;
using Global.System.MessageBrokers.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.MessageBrokers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessageBrokerRouter.ServiceName,
        menuName = MessageBrokerRouter.ServicePath)]
    public class MessageBrokerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var broker = new MessageBroker();
            Msg.Inject(broker);

            services.RegisterInstance(broker)
                .As<IMessageBroker>()
                .AsSelfResolvable();
        }
    }
}