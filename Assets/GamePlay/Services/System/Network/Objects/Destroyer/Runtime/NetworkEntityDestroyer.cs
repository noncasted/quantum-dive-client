using GamePlay.System.Network.Objects.Definition;
using GamePlay.System.Network.Room.Lifecycle.Runtime;

namespace GamePlay.System.Network.Objects.Destroyer.Runtime
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