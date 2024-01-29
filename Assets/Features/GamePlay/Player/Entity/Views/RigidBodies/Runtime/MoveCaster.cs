using GamePlay.Player.Entity.Views.RigidBodies.Debug.Gizmos;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RigidBodies.Runtime
{
    public class MoveCaster
    {
        public MoveCaster(
            CircleCollider2D collider,
            ContactFilter2D contactFilter,
            IRigidBodyGizmosDrawer drawer)
        {
            _collider = collider;
            _contactFilter = contactFilter;
            _drawer = drawer;
        }

        private readonly CircleCollider2D _collider;
        private readonly ContactFilter2D _contactFilter;
        private readonly IRigidBodyGizmosDrawer _drawer;

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
            var resultCount = Physics2D.CircleCast(
                currentPosition,
                _collider.radius,
                direction,
                _contactFilter,
                _buffer,
                distance);

            _drawer.DrawCast(currentPosition, direction, distance, _collider.radius);

            var activeAxisDirection = direction.x == 0f ? direction.y : direction.x;

            if (resultCount == 0)
                return activeAxisDirection * distance;

            return 0f;

            // Removed due to bugs with walls collision
            // var overlapDistance = _buffer[0].distance;
            //
            // if (Mathf.Approximately(overlapDistance, 0f) == true)
            // {
            //     var colliderDistance = _buffer[0].collider.Distance(_collider);
            //     overlapDistance = colliderDistance.distance;
            // }
            //
            // _drawer.DrawHit(_buffer[0].point, _buffer[0].normal);
            //
            // return activeAxisDirection * overlapDistance;
        }
    }
}