using UnityEngine;

namespace GamePlay.Projectiles.Entity.Views.Transforms
{
    [DisallowMultipleComponent]
    public class ProjectileTransform : MonoBehaviour, IProjectileTransform
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public Vector2 Position => _transform.position;

        public void SetPosition(Vector2 position)
        {
            _transform.position = position;
        }

        public void SetRotation(float angle)
        {
            _transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        public void SetScale(float scale)
        {
            _transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}