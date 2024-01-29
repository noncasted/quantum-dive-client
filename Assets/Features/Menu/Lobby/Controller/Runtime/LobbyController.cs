using System;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Lifecycle.Runtime;
using Global.Network.Session.Runtime.Leave;
using Global.System.MessageBrokers.Runtime;
using Menu.Lobby.Controller.Runtime.Timer;
using Menu.Lobby.UI.Runtime.Status;
using Menu.Lobby.UI.Runtime.View;

namespace Menu.Lobby.Controller.Runtime
{
    public class LobbyController : IScopeSwitchListener, ILobbyController
    {
        public LobbyController(
            ISessionLeave leave,
            ILobbyView view,
            IRoomProvider roomProvider,
            ILobbyTimer timer)
        {
            _leave = leave;
            _view = view;
            _roomProvider = roomProvider;
            _timer = timer;
        }
        
        private readonly ISessionLeave _leave;
        private readonly ILobbyView _view;
        private readonly IRoomProvider _roomProvider;
        private readonly ILobbyTimer _timer;

        private IDisposable _backRequestListener;
        private IDisposable _playRequestListener;
        
        public void OnEnabled()
        {
            _backRequestListener = Msg.Listen<LobbyBackRequestEvent>(OnBackRequested);
            _playRequestListener = Msg.Listen<LobbyPlayRequestEvent>(OnPlayRequested);
        }

        public void OnDisabled()
        {
            _backRequestListener?.Dispose();
            _playRequestListener?.Dispose();
        }
        
        public void Enter()
        {
            var roomId = _roomProvider.Id;
            
            _view.Status.Construct(roomId);
            
            
            if (_roomProvider.IsOwner == true)
                _view.Status.ShowPlayButton();
            else
                _view.Status.HidePlayButton();
            
            _view.Status.HideTimer();
        }

        private void OnBackRequested(LobbyBackRequestEvent request)
        {
            ProcessBack().Forget();
        }
        
        private void OnPlayRequested(LobbyPlayRequestEvent request)
        {
            ProcessPlay().Forget();
        }

        private async UniTask ProcessBack()
        {
            await _leave.Leave();
            
            Msg.Publish(new TransitMenuRequestEvent());
        }
        
        private async UniTask ProcessPlay()
        {
            _view.Status.ShowTimer();
            _view.Status.HidePlayButton();

            await _timer.Delay();
            
            _view.Status.HideTimer();
            
            if (_roomProvider.IsOwner == true)
                _view.Status.ShowPlayButton();
            else
                _view.Status.HidePlayButton();
            
            Msg.Publish(new TransitLevelRequestEvent());
        }
    }   
}       