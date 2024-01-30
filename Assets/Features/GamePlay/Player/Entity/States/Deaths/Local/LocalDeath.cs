using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Views.Hitboxes.Local;

namespace GamePlay.Player.Entity.States.Deaths.Local
{
    public class LocalDeath : IDeath, IPlayerLocalState
    {
        public LocalDeath(
            IHitbox hitbox,
            DeathDefinition definition)
        {
            _hitbox = hitbox;
            Definition = definition;
        }

        private readonly IHitbox _hitbox;
        
        public PlayerStateDefinition Definition { get; }

        public void Enter()
        {
        }

        public void Break()
        {
        }
    }
}