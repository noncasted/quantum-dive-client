using UnityEngine;

namespace GamePlay.Player.Entity.Views.RigidBodies.Runtime
{
    public interface IPlayerRigidBody
    {
        Vector2 Position { get; }

        void SetPosition(Vector2 position);
        void Move(Vector2 direction, float distance);
        void SetVelocity(Vector2 direction, float force);
        void ResetVelocity();
    }
}