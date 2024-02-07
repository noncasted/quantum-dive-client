using UnityEngine;

namespace GamePlay.Combat.Projectiles.Entity.Components
{
    public struct ProjectileMoveComponent
    {
        public void Construct(Vector2 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        private Vector2 _direction;
        private float _speed;

        public Vector2 Direction => _direction;
        public float Speed => _speed;
    }
}