using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Entity.Views.Triggers
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider))]
    public class ProjectileTrigger : MonoBehaviour, IProjectileTrigger
    {
        private bool _triggered;
        private IDamageReceiver _receiver;
        
        public bool Triggered => _triggered;
        public IDamageReceiver Receiver => _receiver;

        private void OnEnable()
        {
            _triggered = false;
        }

        private void OnDisable()
        {
            _triggered = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageReceiver receiver) == false)
            {
                Debug.LogError($"Wrong projectile trigger with: {other.name}");
                return;
            }

            _triggered = true;
            _receiver = receiver;
        }
    }
}