using Cysharp.Threading.Tasks;
using Global.System.MessageBrokers.Common;
using Global.System.MessageBrokers.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Global.System.MessageBrokers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessageBrokerRouter.ServiceName,
        menuName = MessageBrokerRouter.ServicePath)]
    public class MessageBrokerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private MessageBrokerLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<MessageBrokerLogger>()
                .WithParameter(_logSettings);

            var messageBroker = new MessageBroker();
            var asyncMessageBroker = new AsyncMessageBroker();

            services.Register<MessageBrokerProxy>()
                .WithParameter(messageBroker)
                .WithParameter(asyncMessageBroker)
                .AsSelfResolvable();
        }
    }
}