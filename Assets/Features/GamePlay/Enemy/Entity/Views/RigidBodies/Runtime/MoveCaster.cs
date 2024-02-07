using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.RigidBodies.Runtime
{
    public class MoveCaster
    {
        public MoveCaster(CircleCollider2D collider, LayerMask collideMask)
        {
            _collider = collider;
            _collideMask = collideMask;
        }

        private readonly CircleCollider2D _collider;
        private readonly LayerMask _collideMask;
        private readonly RaycastHit2D[] _buffer = new RaycastHit2D[1];

        public Vector2 ProcessMove(Vector2 currentPosition, Vector2 direction, float distance)
        {
            var resultPosition = currentPosition;

            if (Mathf.Approximately(direction.x, 0f) == false)
                resultPosition.x += CastInDirection(currentPosition, new Vector2(direction.x, 0f), distance);


            if (Mathf.Approximately(direction.y, 0f) == false)
                resultPosition.y += CastInDirection(currentPosition, new Vector2(0f, direction.y), distance);

            return resultPosition;
        }

        private float CastInDirection(Vector2 currentPosition, Vector2 direction, float distance)
        {
            var castPosition = currentPosition;

            var activeAxisDirection = direction.x == 0f ? direction.y : direction.x;
            castPosition += direction * distance;

            var resultCount = Physics2D.CircleCastNonAlloc(
                castPosition,
                _collider.radius,
                direction,
                _buffer,
                distance,
                _collideMask);

            if (resultCount == 0)
                return activeAxisDirection * distance;

            var overlapDistance = _buffer[0].distance;

            if (Mathf.Approximately(overlapDistance, 0f) == true)
            {
                var colliderDistance = _buffer[0].collider.Distance(_collider);

                overlapDistance = colliderDistance.distance;
            }

            return activeAxisDirection * overlapDistance;
        }
    }
}