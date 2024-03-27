using Cysharp.Threading.Tasks;
using Global.System.MessageBrokers.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

//using UniRx;

namespace Global.System.MessageBrokers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessageBrokerRouter.ServiceName,
        menuName = MessageBrokerRouter.ServicePath)]
    public class MessageBrokerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            // var messageBroker = new MessageBroker();
            // var asyncMessageBroker = new AsyncMessageBroker();

            // services.Register<MessageBrokerProxy>()
            //     .WithParameter(messageBroker)
            //     .WithParameter(asyncMessageBroker)
            //     .AsSelfResolvable();
        }
    }
}