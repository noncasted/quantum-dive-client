using System;
using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Damages
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    public class DamageTrigger : MonoBehaviour, IDamageTrigger
    {
        public event Action<IDamageReceiver> Triggered;

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageReceiver damageReceiver) == false)
            {
                Debug.LogError($"Wrong attack trigger with: {other.name}");
                return;
            }

            Triggered?.Invoke(damageReceiver);
        }
    }
}