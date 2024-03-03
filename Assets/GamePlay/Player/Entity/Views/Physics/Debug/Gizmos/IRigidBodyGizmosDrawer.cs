using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Debug.Gizmos
{
    public interface IRigidBodyGizmosDrawer
    {
        void DrawCast(Vector2 origin, Vector2 direction, float distance, float radius);
        void DrawHit(Vector2 origin, Vector2 normal);
    }
}