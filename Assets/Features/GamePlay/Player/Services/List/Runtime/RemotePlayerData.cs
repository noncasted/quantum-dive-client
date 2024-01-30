using GamePlay.Player.Entity.Setup.Root.Remote;
using Ragon.Client;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public class RemotePlayerData
    {
        public RemotePlayerData(RagonEntity entity, IRemotePlayerRoot root)
        {
            Entity = entity;
            Root = root;
        }
        
        public readonly RagonEntity Entity;
        public readonly IRemotePlayerRoot Root;
    }
}