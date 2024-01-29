using System;
using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    [DisallowMultipleComponent]
    public class DamageReceiverTrigger : MonoBehaviour, IDamageReceiver, IDamageReceiverTrigger
    {
        private Collider2D _collider;

        public float Radius { get; }
        public Vector2 Position => transform.position;

        public event Action<Damage> Triggered;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public void ReceiveDamage(Damage damage)
        {
            Triggered?.Invoke(damage);
        }

        public void Enable()
        {
            _collider.enabled = true;
        }

        public void Disable()
        {
            _collider.enabled = false;
        }
    }
}