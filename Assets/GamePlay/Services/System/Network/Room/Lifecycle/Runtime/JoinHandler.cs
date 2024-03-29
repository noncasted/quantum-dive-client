﻿using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Abstract;
using Ragon.Client;

namespace GamePlay.Services.Network.Room.Lifecycle.Runtime
{
    public class JoinHandler : IRagonJoinListener
    {
        public JoinHandler(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;

            _completion = new UniTaskCompletionSource();
        }

        private readonly UniTaskCompletionSource _completion;
        private readonly IClientProvider _clientProvider;

        public async UniTask ProcessJoin()
        {
            var client = _clientProvider.Client;

            client.AddListener(this);
            await _completion.Task;
            await UniTask.Yield();
            client.RemoveListener(this);

            await UniTask.Yield();
        }

        public void OnJoined(RagonClient client)
        {
            _completion.TrySetResult();
        }
    }
}