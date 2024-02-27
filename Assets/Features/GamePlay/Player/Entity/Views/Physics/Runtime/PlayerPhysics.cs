using GamePlay.Player.Entity.Views.Physics.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    public class PlayerPhysics : IPlayerPhysics
    {
        public PlayerPhysics(PlayerPhysicsView view, PhysicsLogger logger)
        {
            _view = view;
            _logger = logger;
        }

        private readonly PhysicsLogSettings _logSettings;
        private readonly PlayerPhysicsView _view;
        private readonly PhysicsLogger _logger;

        public Vector3 Position => _view.position;

        public void SetPosition(Vector3 position)
        {
            _view.SetPosition(position);
        }

        public void Move(Vector2 direction, float distance)
        {
            var convertedDirection = new Vector3(direction.normalized.x, 0f, direction.normalized.y);
            var position = _view.position + convertedDirection * distance;

            _view.SetPosition(position);

            _logger.OnMoveEnqueued(direction, distance);
        }

        public void SetVelocity(Vector2 direction, float force)
        {
            var convertedDirection = new Vector3(direction.normalized.x, 0f, direction.normalized.y);
            var velocity = convertedDirection * force;

            _view.SetVelocity(velocity);
        }

        public void ResetVelocity()
        {
            _view.SetVelocity(Vector3.zero);
        }
    }
}