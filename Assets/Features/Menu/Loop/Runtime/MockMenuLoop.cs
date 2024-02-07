using System;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Global.System.MessageBrokers.Runtime;
using Menu.Lobby.Controller.Runtime;
using Menu.Lobby.UI.Runtime.View;
using Menu.Main.Controller.Runtime;
using Menu.Main.UI.Runtime;
using Menu.Services.Network.Entity.Runtime;
using Ragon.Client;

namespace Menu.Loop.Runtime
{
    public class MockMenuLoop : IScopeSwitchListener
    {
        public MockMenuLoop(
            IMenuView menu,
            ILobbyView lobby,
            ILobbyController controller,
            IMenuEntity entity)
        {
            _menu = menu;
            _lobby = lobby;
            _controller = controller;
            _entity = entity;
        }

        private readonly IMenuView _menu;
        private readonly ILobbyView _lobby;
        private readonly ILobbyController _controller;
        private readonly IMenuEntity _entity;

        private IDisposable _transitLobbyRequestListener;
        private IDisposable _transitMenuRequestListener;
        private IDisposable _transitLevelRequestListener;
        
        public void OnEnabled()
        {
            _transitLobbyRequestListener = Msg.Listen<TransitLobbyRequestEvent>(OnTransitLobbyRequested);
            _transitMenuRequestListener = Msg.Listen<TransitMenuRequestEvent>(OnTransitMenuRequested);
            _transitLevelRequestListener = Msg.Listen<TransitLevelRequestEvent>(OnTransitLevelRequested);
            
            _entity.Created += OnEntityCreated;
            
            _menu.Open();
        }

        public void OnDisabled()
        {
            _transitLobbyRequestListener?.Dispose();
            _transitMenuRequestListener?.Dispose();
            _transitLevelRequestListener?.Dispose();
            
            _entity.Created -= OnEntityCreated;
        }

        private void OnEntityCreated()
        {
            _entity.ListenEvent<LevelTransitionEvent>(OnLevelTransition);
        }
        
        private void OnTransitLobbyRequested(TransitLobbyRequestEvent request)
        {
            _controller.Enter();

            _menu.Close();
            _lobby.Open();
        }

        private void OnTransitMenuRequested(TransitMenuRequestEvent request)
        {
            _lobby.Close();
            _menu.Open();
        }
        
        private void OnTransitLevelRequested(TransitLevelRequestEvent request)
        {
            _entity.ReplicateEvent(new LevelTransitionEvent());
        }

        private void OnLevelTransition(RagonPlayer player, LevelTransitionEvent data)
        {
            Msg.Publish(new LevelTransitionRequestEvent());
        }
    }
}