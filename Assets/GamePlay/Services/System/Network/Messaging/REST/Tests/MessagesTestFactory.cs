using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.System.Network.Messaging.REST.Tests
{
    public class MessagesTestFactory : IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var view = Object.FindFirstObjectByType<MessagesTestView>();
            
            services.RegisterComponent(view)
                .AsCallbackListener()
                .AsSelfResolvable()
                .AsSelf();
        }
    }
}