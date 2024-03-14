using System;
using UnityEngine;

namespace GamePlay.Projectiles.Entity.Views.Actions
{
    public class ProjectileActions : MonoBehaviour, IProjectileActions
    {
        private Action _returnToPool;

        public bool RequiresCollisionNormal => false;

        public void Construct(Action returnToPool)
        {
            _returnToPool = returnToPool;
        }

        public void OnTaken()
        {
            
        }

        public void OnCollision()
        {
            _returnToPool?.Invoke();
        }

        public void OnCollision(Vector3 targetNormal)
        {
        }

        public void OnHit()
        {
            _returnToPool?.Invoke();
        }

        public void OnDestroyed()
        {
            _returnToPool?.Invoke();
        }
    }
}