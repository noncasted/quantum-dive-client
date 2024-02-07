using Ragon.Client;

namespace GamePlay.Player.Entity.Definition
{
    public class PlayerEntity : IPlayerEntity
    {
        public PlayerEntity(RagonEntity entity, IPlayerRoot root)
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