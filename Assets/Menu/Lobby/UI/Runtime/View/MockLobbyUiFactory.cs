using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Lobby.UI.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Lobby.UI.Runtime.View
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LobbyUiRoutes.MockName,
        menuName = LobbyUiRoutes.MockPath)]
    public class MockLobbyUiFactory : BaseLobbyUiFactory
    {
        public async override UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var view = FindFirstObjectByType<LobbyView>();

            services.RegisterComponent(view)
                .As<ILobbyView>();

            view.Inject(services);
        }
    }
}