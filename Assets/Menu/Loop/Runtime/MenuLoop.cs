using System;
using Cysharp.Threading.Tasks;
using Global.Network.Connection.Abstract;
using Global.System.MessageBrokers.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Lobby.Controller.Runtime;
using Menu.Lobby.UI.Runtime.View;
using Menu.Main.Controller.Runtime;
using Menu.Main.UI.Runtime;
using Menu.Services.Network.Entity.Runtime;
using Ragon.Client;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Menu.Loop.Runtime
{
    public class MenuLoop : IScopeSwitchListener
    {
        public MenuLoop(
            IConnection connection,
            IMenuView menu,
            ILobbyView lobby,
            ILobbyController controller,
            IMenuEntity entity)
        {
            _connection = connection;
            _menu = menu;
            _lobby = lobby;
            _controller = controller;
            _entity = entity;
        }

        private readonly IConnection _connection;
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
            
            Connect().Forget();
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
        
        private async UniTask Connect()
        {
            _menu.OnLoading();
            var result = await _connection.Connect($"Player_{Random.Range(0,100)}");
            _menu.CancelLoading();
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
            Debug.Log("Send level");
            _entity.ReplicateEvent(new LevelTransitionEvent());
        }

        private void OnLevelTransition(RagonPlayer player, LevelTransitionEvent data)
        {
            Msg.Publish(new LevelTransitionRequestEvent());
        }
    }
}