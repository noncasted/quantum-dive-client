﻿using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Player.Entity.Views.Hitboxes.Common;
using GamePlay.Player.Entity.Views.Hitboxes.Network;
using GamePlay.Services.Combat.Hitboxes.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Hitboxes.Remote
{
    public class RemoteHitbox : IEntitySwitchLifetimeListener, IDamageReceiver
    {
        public RemoteHitbox(
            IHitboxRegistry hitboxRegistry,
            IEntityEvents events,
            IHitboxSync stateSync,
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
        private readonly IHitboxSync _stateSync;
        private readonly IHitboxConfig _config;

        private readonly Transform _point;

        public float Radius => _config.Radius;
        public Vector3 Position => _point.position;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateSync.StateChanged.Listen(lifetime, OnStateChanged);
        }

        public void ReceiveDamage(Damage damage)
        {
            var payload = new PlayerDamageReceivedEvent
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