using Internal.Scopes.Abstract.Containers;
using Menu.Lobby.UI.Runtime.Players;
using Menu.Lobby.UI.Runtime.Status.Timer;
using UnityEngine;

namespace Menu.Lobby.UI.Runtime.View
{
    [DisallowMultipleComponent]
    public class LobbyBootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayersListView _playersListView;
        [SerializeField] private LobbyTimerView _timerView;
        
        public void Inject(IServiceCollection services)
        {
            services.Inject(_playersListView);

            services.RegisterComponent(_timerView)
                .As<ILobbyTimerView>();
        }
    }
}