using UnityEngine;

namespace GamePlay.Combat.Projectiles.Entity.Components
{
    public struct ProjectileMoveHistoryComponent
    {
        private Vector2 _previous;
        private Vector2 _current;
        private float _distance;

        public Vector2 Previous => _previous;
        public Vector2 Current => _current;
        public float Distance => _distance;

        public void Construct(Vector2 position)
        {
            _previous = position;
            _current = position;
        }

        public void OnPositionChanged(Vector2 newPosition, float distance)
        {
            _distance = distance;
            _previous = _current;
            _current = newPosition;
        }
    }
}