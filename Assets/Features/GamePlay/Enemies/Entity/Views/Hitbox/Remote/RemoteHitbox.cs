using GamePlay.Common.Damages;
using GamePlay.Enemies.Entity.Network.EntityHandler;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.Views.Hitbox.Common;
using GamePlay.Hitboxes.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Remote
{
    public class RemoteHitbox : IEntitySwitchListener, IDamageReceiver
    {
        public RemoteHitbox(
            IHitboxRegistry hitboxRegistry,
            IEntityEvents events,
            IHitboxStateSync stateSync,
            IHitboxConfig config,
            Transform point)
        {
            _hitboxRegistry = hitboxRegistry;
            _events = events;
            _stateSync = stateSync;
            _point = point;
            _config = config;
        }

        private readonly IHitboxRegistry _hitboxRegistry;
        private readonly IEntityEvents _events;
        private readonly IHitboxStateSync _stateSync;
        private readonly IHitboxConfig _config;

        private readonly Transform _point;

        public float Radius => _config.Radius;
        public Vector2 Position => _point.position;

        public void OnEnabled()
        {
            _stateSync.StateChanged += OnStateChanged;
        }

        public void OnDisabled()
        {
            _stateSync.StateChanged -= OnStateChanged;
        }

        public void ReceiveDamage(Damage damage)
        {
            var payload = new EnemyDamageReceivedEvent()
            {
                Damage = damage
            };

            _events.ReplicateEvent(payload);
        }

        private void OnStateChanged(bool isActive)
        {
            if (isActive == true)
                _hitboxRegistry.AddEnemy(this);
            else
                _hitboxRegistry.Remove(this);
        }
    }
}