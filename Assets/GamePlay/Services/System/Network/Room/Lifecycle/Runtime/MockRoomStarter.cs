using Cysharp.Threading.Tasks;
using GamePlay.System.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;

namespace GamePlay.System.Network.Room.Lifecycle.Runtime
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