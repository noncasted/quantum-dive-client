using System;
using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Common
{
    [DisallowMultipleComponent]
    public class EnemyHitboxTrigger : MonoBehaviour, IHitboxTrigger, IDamageReceiver
    {
        public float Radius => 0f;
        public Vector2 Position => transform.position;

        public event Action<Damage> Triggered;

        public void ReceiveDamage(Damage damage)
        {
            Triggered?.Invoke(damage);
        }
    }
}