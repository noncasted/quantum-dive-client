using Cysharp.Threading.Tasks;
using GamePlay.Services.System.Network.Room.EventLoops.Abstract;
using GamePlay.Services.System.Network.Room.Lifecycle.Abstract;
using Global.Network.Handlers.ClientHandler.Abstract;

namespace GamePlay.Network.Room.Lifecycle.Runtime
{
    public class MockRoomStarter : INetworkDestroyListener
    {
        public MockRoomStarter(IRoomLifecycle lifecycle, IClientProvider clientProvider)
        {
            _lifecycle = lifecycle;
            _clientProvider = clientProvider;
        }

        private readonly IRoomLifecycle _lifecycle;
        private readonly IClientProvider _clientProvider;

        public async UniTask OnNetworkDestroy()
        {
            var joinHandler = new JoinHandler(_clientProvider);
            var joinTask = joinHandler.ProcessJoin();
            
            _lifecycle.SceneLoaded();

            await joinTask;
        }
    }
}