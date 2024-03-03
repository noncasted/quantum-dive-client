using Common.Architecture.Container.Abstract;
using Menu.Lobby.UI.Runtime.Status;
using UnityEngine;

namespace Menu.Lobby.UI.Runtime.View
{
    [DisallowMultipleComponent]
    public class LobbyView : MonoBehaviour, ILobbyView
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private LobbyBootstrapper _bootstrapper;
        [SerializeField] private LobbyStatus _status;

        public ILobbyStatus Status => _status;
        
        private void Awake()
        {
            _body.SetActive(false);
        }

        public void Open()
        {
            _body.SetActive(true);
        }

        public void Close()
        {
            _body.SetActive(false);
        }

        public void Inject(IServiceCollection services)
        {
            _bootstrapper.Inject(services);
        }
    }
}