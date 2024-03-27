using UnityEngine;

namespace GamePlay.Services.Projectiles.Entity.Views.Transforms
{
    [DisallowMultipleComponent]
    public class ProjectileTransform : MonoBehaviour, IProjectileTransform
    {
        private Transform _transform;
        
        public Vector3 Position => _transform.position;

        private void Awake()
        {
            _transform = transform;
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }

        public void SetRotation(float angle)
        {
            _transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        public void SetScale(float scale)
        {
            _transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}