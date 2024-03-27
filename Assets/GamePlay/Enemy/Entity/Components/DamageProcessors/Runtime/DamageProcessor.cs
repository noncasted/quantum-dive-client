using GamePlay.Common.Damages;
using GamePlay.Enemy.Entity.Components.Health.Abstract;
using GamePlay.Enemy.Entity.States.Damaged.Local;
using GamePlay.Enemy.Entity.States.Death.Local;
using GamePlay.Enemy.Entity.Views.Hitbox.Local;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Enemy.Entity.Components.DamageProcessors.Runtime
{
    public class DamageProcessor : IEntitySwitchLifetimeListener
    {
        public DamageProcessor(
            IHitbox hitbox,
            IHealth health,
            IDamaged damaged,
            IDeath death)
        {
            _hitbox = hitbox;
            _health = health;
            _damaged = damaged;
            _death = death;
        }

        private readonly IHitbox _hitbox;
        private readonly IHealth _health;
        private readonly IDamaged _damaged;
        private readonly IDeath _death;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
           // _hitbox.DamageReceived.Listen(lifetime, ProcessDamage);   
        }
        
        private void ProcessDamage(Damage damage)
        {
            // _health.Remove(damage.Amount);
            //
            // if (_health.IsAlive == true)
            //     _damaged.Enter(damage.Direction, damage.PushForce).Forget();
            // else
            //     _death.Enter();
        }
    }
}