using UnityEngine;

namespace GamePlay.Services.Projectiles.Entity.Views.Transforms
{
    public interface IProjectileTransform
    {
        Vector3 Position { get; }

        void SetPosition(Vector3 position);
        void SetRotation(float angle);
        void SetScale(float scale);
    }
}