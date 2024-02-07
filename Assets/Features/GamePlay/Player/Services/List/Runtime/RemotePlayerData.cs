using GamePlay.Player.Entity.Definition;
using Ragon.Client;

namespace GamePlay.Player.List.Runtime
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