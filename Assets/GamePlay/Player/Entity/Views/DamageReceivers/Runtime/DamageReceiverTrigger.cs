using Common.DataTypes.Runtime.Reactive;
using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Views.DamageReceivers.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    [DisallowMultipleComponent]
    public class DamageReceiverTrigger : MonoBehaviour, IDamageReceiver, IDamageReceiverTrigger
    {
        private Collider2D _collider;
        private readonly ViewableDelegate<Damage> _triggered = new();

        public Vector3 Position => transform.position; 

        public IViewableDelegate<Damage> Triggered => _triggered;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public void ReceiveDamage(Damage damage)
        {
            _triggered?.Invoke(damage);
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