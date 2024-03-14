using UnityEngine;

namespace GamePlay.Projectiles.Entity.Components
{
    public struct ProjectileMoveComponent
    {
        public void Construct(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        private Vector3 _direction;
        private float _speed;

        public Vector3 Direction => _direction;
        public float Speed => _speed;
    }
}