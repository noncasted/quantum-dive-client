using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Data;
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

        public async override UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var scene = await utils.SceneLoader.LoadTyped<LobbyView>(_scene);

            var view = scene.Searched;

            services.RegisterComponent(view)
                .As<ILobbyView>();
            
            view.Inject(services);
        }
    }
}