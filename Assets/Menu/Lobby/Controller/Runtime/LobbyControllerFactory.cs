using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Lobby.Controller.Common;
using Menu.Lobby.Controller.Runtime.Timer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Lobby.Controller.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LobbyControllerRoutes.ServiceName,
        menuName = LobbyControllerRoutes.ServicePath)]
    public class LobbyControllerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<LobbyController>()
                .As<ILobbyController>()
                .AsCallbackListener();

            services.Register<LobbyTimer>()
                .As<ILobbyTimer>();
        }
    }
}