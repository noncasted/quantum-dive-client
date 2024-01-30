using Features.GamePlay.Player.Entity.Setup.Root.Common;
using Ragon.Client;

namespace Features.GamePlay.Player.Services.List.Definition
{
    public class NetworkPlayer : INetworkPlayer
    {
        public NetworkPlayer(RagonEntity entity, IPlayerRoot root)
        {
            _entity = entity;
            _root = root;
        }
        
        private readonly RagonEntity _entity;
        private readonly IPlayerRoot _root;

        public RagonEntity Entity => _entity;
        public IPlayerRoot Root => _root;
    }
}