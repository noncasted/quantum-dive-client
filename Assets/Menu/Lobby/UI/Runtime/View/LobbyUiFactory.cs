using Internal.Scopes.Abstract.Containers;

using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Menu.Lobby.UI.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Lobby.UI.Runtime.View
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LobbyUiRoutes.ServiceName,
        menuName = LobbyUiRoutes.ServicePath)]
    public class LobbyUiFactory : BaseLobbyUiFactory
    {
        [SerializeField] [Scene] private SceneData _scene;

        public async override UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var (_, view) = await utils.SceneLoader.LoadTyped<LobbyView>(_scene);

            services.RegisterComponent(view)
                .As<ILobbyView>();
            
            view.Inject(services);
        }
    }
}