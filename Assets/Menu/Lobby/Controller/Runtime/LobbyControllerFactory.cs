using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
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
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<LobbyController>()
                .As<ILobbyController>()
                .AsCallbackListener();

            services.Register<LobbyTimer>()
                .As<ILobbyTimer>();
        }
    }
}