﻿using System;
using Cysharp.Threading.Tasks;
using Global.Network.Connection.Abstract;
using Global.Network.Connection.Configuration;
using Global.Network.Handlers.ClientHandler.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace Global.Network.Connection.Runtime
{
    public class Connection : IConnection, IRagonConnectionListener
    {
        public Connection(
            IClientProvider clientProvider,
            IRagonConnectionOptions options)
        {
            _clientProvider = clientProvider;
            _options = options;
        }
        
        private readonly IClientProvider _clientProvider;
        private readonly IRagonConnectionOptions _options;

        public event Action Disconnected;
        
        public async UniTask<ConnectionResultType> Connect(string playerName)
        {
            var attempt = new ConnectionAttempt(_clientProvider.Client, _options);

            var result = await attempt.Connect(playerName);

            return result;
        }


        public void OnConnected(RagonClient client)
        {
        }

        public void OnDisconnected(RagonClient client, RagonDisconnect reason)
        {
            
        }

        public void OnDisconnected(RagonClient client)
        {
            Disconnected?.Invoke();
        }
    }
}