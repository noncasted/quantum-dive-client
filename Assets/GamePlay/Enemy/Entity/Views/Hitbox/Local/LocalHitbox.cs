using Common.DataTypes.Reactive;
using GamePlay.Common.Damages;
using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Enemy.Entity.Views.Hitbox.Common;
using GamePlay.Services.Combat.Hitboxes.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Local
{
    public class LocalHitbox : IDamageReceiver, IHitbox, IEntitySwitchLifetimeListener
    {
        public LocalHitbox(
            IHitboxRegistry hitboxRegistry,
            IHitboxStateSync stateSync,
            IEntityEvents events,
            IHitboxTrigger trigger,
            Transform point,
            IHitboxConfig config)
        {
            _hitboxRegistry = hitboxRegistry;
            _stateSync = stateSync;
            _events = events;
            _trigger = trigger;
            _point = point;
            _config = config;
        }
        
        private readonly IHitboxRegistry _hitboxRegistry;
        private readonly IHitboxStateSync _stateSync;
        private readonly IEntityEvents _events;
        private readonly IHitboxTrigger _trigger;

        private readonly Transform _point;
        private readonly IHitboxConfig _config;

        public float Radius => _config.Radius;
        public Vector3 Position => _point.position;

        public IViewableDelegate<Damage> DamageReceived { get; } = new ViewableDelegate<Damage>();

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _events.ListenEvent<EnemyDamageReceivedEvent>(lifetime, OnRemoteDamageReceived);
        }
        
        public void Enable()
        {
            _hitboxRegistry.AddEnemy(this);
            _trigger.Triggered += ReceiveDamage;
            _stateSync.SendEnable();
        }

        public void Disable()
        {
            _hitboxRegistry.Remove(this);
            _trigger.Triggered -= ReceiveDamage;
            _stateSync.SendDisable();
        }

        public void ReceiveDamage(Damage damage)
        {
            DamageReceived.Invoke(damage);
        }
        
        private void OnRemoteDamageReceived(RagonPlayer player, EnemyDamageReceivedEvent payload)
        {
            DamageReceived.Invoke(payload.Damage);
        }
    }
}