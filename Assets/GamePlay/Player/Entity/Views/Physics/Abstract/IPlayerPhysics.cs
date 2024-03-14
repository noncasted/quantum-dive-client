using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Abstract
{
    public interface IPlayerPhysics
    {
        Vector3 Position { get; }
        Vector3 Rotation { get; }

        void SetPosition(Vector3 position);
        void Move(Vector2 direction, float distance);
        void SetVelocity(Vector2 direction, float force);
        void SetForwardVelocity(float force);
        void LockCurrentRotation();
        void Rotate(Vector2 direction);
        void Rotate(float angle);
        void ResetVelocity();
    }
}