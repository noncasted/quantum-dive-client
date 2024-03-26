using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Abstract;
using Global.Network.Handlers.ClientHandler.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ClientHandlerRoutes.ServiceName, menuName = ClientHandlerRoutes.ServicePath)]
    public class ClientHandlerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<ClientFactory>()
                .As<IClientFactory>();

            services.Register<ClientHandler>()
                .As<IClientProvider>()
                .AsCallbackListener();
        }
    }
}