using GamePlay.Services.Network.Objects.Definition;
using GamePlay.Services.System.Network.Objects.Destroyer.Abstract;
using GamePlay.Services.System.Network.Room.Lifecycle.Abstract;

namespace GamePlay.Services.Network.Objects.Destroyer.Runtime
{
    public class NetworkEntityDestroyer : INetworkEntityDestroyer
    {
        public NetworkEntityDestroyer(IRoomProvider roomProvider)
        {
            _roomProvider = roomProvider;
        }
        
        private readonly IRoomProvider _roomProvider;
        
        public void Destroy(INetworkObject networkObject)
        {
            _roomProvider.Room.DestroyEntity(networkObject.Entity);
        }
    }
}