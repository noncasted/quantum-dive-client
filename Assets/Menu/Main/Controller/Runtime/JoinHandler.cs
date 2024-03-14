using Cysharp.Threading.Tasks;
using GamePlay.Services.System.Network.Room.Lifecycle.Abstract;
using Global.Network.Handlers.ClientHandler.Abstract;
using Menu.Services.Network.PlayersLists.Runtime;
using Ragon.Client;

namespace Menu.Main.Controller.Runtime
{
    public class JoinHandler : IRagonJoinListener
    {
        public JoinHandler(
            IPlayersList playersList,
            IRoomProvider roomProvider,
            IClientProvider clientProvider)
        {
            _playersList = playersList;
            _roomProvider = roomProvider;
            _clientProvider = clientProvider;

            _completion = new UniTaskCompletionSource();
        }

        private readonly UniTaskCompletionSource _completion;
        private readonly IPlayersList _playersList;
        private readonly IRoomProvider _roomProvider;
        private readonly IClientProvider _clientProvider;

        public async UniTask ProcessJoin()
        {
            var client = _clientProvider.Client;

            client.AddListener(this);
            await _completion.Task;
            await UniTask.Yield();
            client.RemoveListener(this);

            await UniTask.Yield();

            _playersList.AddPlayer(_roomProvider.LocalPlayer);
        }

        public void OnJoined(RagonClient client)
        {
            _completion.TrySetResult();
        }
    }
}