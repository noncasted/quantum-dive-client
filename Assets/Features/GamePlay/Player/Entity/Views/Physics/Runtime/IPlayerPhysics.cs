using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    public interface IPlayerPhysics
    {
        Vector3 Position { get; }

        void SetPosition(Vector3 position);
        void Move(Vector2 direction, float distance);
        void SetVelocity(Vector2 direction, float force);
        void ResetVelocity();
    }
}