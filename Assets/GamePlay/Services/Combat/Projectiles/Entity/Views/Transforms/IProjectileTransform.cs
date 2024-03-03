using UnityEngine;

namespace GamePlay.Combat.Projectiles.Entity.Views.Transforms
{
    public interface IProjectileTransform
    {
        Vector2 Position { get; }

        void SetPosition(Vector2 position);
        void SetRotation(float angle);
        void SetScale(float scale);
    }
}