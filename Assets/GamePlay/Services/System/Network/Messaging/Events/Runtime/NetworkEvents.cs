using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Services.Network.Room.Entities.Factory;
using GamePlay.Services.System.Network.Messaging.Events.Abstract;
using GamePlay.Services.System.Network.Room.EventLoops.Abstract;
using Global.Network.Handlers.ClientHandler.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Services.Network.Messaging.Events.Runtime
{
    public class NetworkEvents : INetworkEvents, IScopeDisableListener, INetworkSceneEntityCreationListener
    {
        public NetworkEvents(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        private readonly IClientProvider _clientProvider;
        private readonly CancellationTokenSource _cancellation = new();

        private readonly List<IDisposable> _listeners = new();

        private RagonEntity _entity;

        public void OnDisabled()
        {
            _cancellation.Cancel();

            foreach (var listener in _listeners)
                listener.Dispose();
        }

        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            _entity = await factory.Create();
        }

        public void AddRoute<TEvent>(Action<RagonPlayer, TEvent> listener) where TEvent : IRagonEvent, new()
        {
            _clientProvider.Client.Event.Register<TEvent>();
            
            var disposable = _entity.OnEvent(listener);
            _listeners.Add(disposable);
        }

        public void AddRouteAsync<TEvent>(Func<RagonPlayer, TEvent, CancellationToken, UniTask> listener)
            where TEvent : IRagonEvent, new()
        {
            _clientProvider.Client.Event.Register<TEvent>();
            var receiver = new EventReceiver<TEvent>(_cancellation.Token, listener);
            var disposable = _entity.OnEvent<TEvent>(receiver.Listener);
            _listeners.Add(disposable);
        }

        public void SendEvent<TEvent>(TEvent payload) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(payload, RagonTarget.All, RagonReplicationMode.LocalAndServer);
        }

        public void SendEvent<TEvent>(TEvent payload, RagonPlayer player) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(payload, player, RagonReplicationMode.Server);
        }
    }
}