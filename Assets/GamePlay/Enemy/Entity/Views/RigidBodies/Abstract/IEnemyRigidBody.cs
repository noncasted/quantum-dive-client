using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Abstract
{
    public interface IEnemyRigidBody
    {
        Vector2 Position { get; }

        void SetPosition(Vector2 position);
        void Move(Vector2 direction, float distance);
        void SetVelocity(Vector2 direction, float force);
        void ResetVelocity();

        void Enable();
        void Disable();
    }
}