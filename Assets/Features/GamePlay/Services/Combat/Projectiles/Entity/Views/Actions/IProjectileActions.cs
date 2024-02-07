using System;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Entity.Views.Actions
{
    public interface IProjectileActions
    {
        bool RequiresCollisionNormal { get; }
        
        public void Construct(Action returnToPool);
        void OnTaken();
        void OnCollision();
        void OnCollision(Vector2 targetNormal);
        void OnHit();
        void OnDestroyed();
    }
}