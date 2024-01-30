using GamePlay.Player.Entity.Setup.Root.Remote;
using Ragon.Client;

namespace GamePlay.Player.Services.List.Runtime
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