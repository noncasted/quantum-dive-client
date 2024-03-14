using Common.DataTypes.Reactive;
using GamePlay.Common.Damages;
using GamePlay.Hitboxes.Runtime;
using GamePlay.Player.Entity.Views.DamageReceivers.Abstract;
using GamePlay.Player.Entity.Views.DamageReceivers.Runtime;
using GamePlay.Player.Entity.Views.Hitboxes.Common;
using GamePlay.Player.Entity.Views.Hitboxes.Network;
using GamePlay.Services.Combat.Hitboxes.Abstract;
using GamePlay.Services.Combat.Targets.Registry.Abstract;
using GamePlay.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Hitboxes.Local
{
    public class LocalHitbox : IDamageReceiver, IHitbox, ITargetPosition
    {
        public LocalHitbox(
            IHitboxRegistry hitboxRegistry,
            ITargetPlayerRegistry targetPlayerRegistry,
            IHitboxConfig config,
            IHitboxSync sync,
            IDamageReceiverHandler damageReceiverHandler,
            Transform point)
        {
            _hitboxRegistry = hitboxRegistry;
            _targetPlayerRegistry = targetPlayerRegistry;
            _point = point;
            _config = config;
            _sync = sync;
            _damageReceiverHandler = damageReceiverHandler;
        }

        private readonly IHitboxRegistry _hitboxRegistry;
        private readonly ITargetPlayerRegistry _targetPlayerRegistry;

        private readonly IHitboxConfig _config;
        private readonly IHitboxSync _sync;
        private readonly IDamageReceiverHandler _damageReceiverHandler;
        private readonly Transform _point;

        public float Radius => _config.Radius;
        public Vector3 Position => _point.position;

        private readonly IViewableDelegate<Damage> _damaged = new ViewableDelegate<Damage>();

        public IViewableDelegate<Damage> Damaged => _damaged;

        public void Enable()
        {
            _hitboxRegistry.AddLocalPlayer(this);
            _targetPlayerRegistry.AddPlayer(this);
            _damageReceiverHandler.Enable();

            _sync.SendEnable();
        }

        public void Disable()
        {
            _hitboxRegistry.Remove(this);
            _targetPlayerRegistry.RemovePlayer(this);
            _damageReceiverHandler.Disable();

            _sync.SendDisable();
        }

        public void ReceiveDamage(Damage damage)
        {
            Damaged?.Invoke(damage);
        }
    }
}