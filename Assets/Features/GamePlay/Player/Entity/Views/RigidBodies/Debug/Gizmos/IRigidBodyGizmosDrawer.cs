using UnityEngine;

namespace GamePlay.Player.Entity.Views.RigidBodies.Debug.Gizmos
{
    public interface IRigidBodyGizmosDrawer
    {
        void DrawCast(Vector2 origin, Vector2 direction, float distance, float radius);
        void DrawHit(Vector2 origin, Vector2 normal);
    }
}