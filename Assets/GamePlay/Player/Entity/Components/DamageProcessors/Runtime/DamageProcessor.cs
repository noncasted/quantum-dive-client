using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Components.DamageProcessors.Abstract;
using GamePlay.Player.Entity.Components.Healths.Abstract;
using GamePlay.Player.Entity.States.Deaths.Local;
using GamePlay.Player.Entity.States.SubStates.Damaged.Local;
using GamePlay.Player.Entity.Views.DamageReceivers.Abstract;
using GamePlay.Player.Entity.Views.Hitboxes.Local;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Runtime
{
    public class DamageProcessor : IEntitySwitchLifetimeListener, IDamageProcessor
    {
        public DamageProcessor(
            IHealth health,
            IDeath death,
            IDamaged damaged,
            IHitbox hitbox,
            IDamageReceiverHandler damageReceiverHandler,
            DamageProcessorConfigAsset config)
        {
            _health = health;
            _death = death;
            _damaged = damaged;
            _hitbox = hitbox;
            _damageReceiverHandler = damageReceiverHandler;
            _config = config;

            _lastTimeDamage = -_config.DamageDelay;
        }

        private readonly DamageProcessorConfigAsset _config;

        private readonly IDeath _death;
        private readonly IDamaged _damaged;
        private readonly IHitbox _hitbox;
        private readonly IDamageReceiverHandler _damageReceiverHandler;
        private readonly IHealth _health;

        private float _lastTimeDamage;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _hitbox.Damaged.Listen(lifetime, OnDamage);
            _damageReceiverHandler.Damaged.Listen(lifetime, OnDamage);
        }
        
        public void OnDamage(Damage damage)
        {
            if (IsDamageAvailable() == false)
                return;

            _health.OnDamage(damage.Amount);
            _lastTimeDamage = Time.time;

            if (_health.IsAlive == true)
                _damaged.Enter(damage.Direction, damage.PushForce);
            else
                _death.Enter();
        }

        private bool IsDamageAvailable()
        {
            var immutability = _lastTimeDamage + _config.DamageDelay;

            if (immutability > Time.time)
                return false;

            return true;
        }
    }
}