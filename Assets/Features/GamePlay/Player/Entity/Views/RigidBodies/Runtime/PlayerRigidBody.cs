using System;
using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime.Callbacks;
using GamePlay.Player.Entity.Views.RigidBodies.Debug.Gizmos;
using GamePlay.Player.Entity.Views.RigidBodies.Logs;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RigidBodies.Runtime
{
    public class PlayerRigidBody :
        IPlayerRigidBody,
        IEntitySwitchListener,
        IFixedUpdatable
    {
        public PlayerRigidBody(
            Rigidbody2D rigidbody,
            CircleCollider2D collider,
            ContactFilter2D contactFilter,
            RigidBodyLogger logger,
            IRigidBodyGizmosDrawer drawer,
            IUpdater updater)
        {
            _rigidbody = rigidbody;
            _collider = collider;
            _logger = logger;
            _updater = updater;

            _moveCaster = new MoveCaster(collider, contactFilter, drawer);
        }

        private readonly RigidBodyLogSettings _logSettings;
        private readonly LayerMask _collideMask;
        private readonly CircleCollider2D _collider;
        private readonly RigidBodyLogger _logger;
        private readonly Rigidbody2D _rigidbody;
        private readonly IUpdater _updater;

        private readonly MoveCaster _moveCaster;

        private readonly RaycastHit2D[] _buffer = new RaycastHit2D[1];
        private readonly Queue<PhysicsInteraction> _interactions = new();

        private readonly Queue<PhysicsMove> _moves = new();
        private readonly Queue<Vector2> _teleports = new();

        private bool _isMovedByVelocity;

        private Vector2 _currentPosition;

        public Vector2 Position => _rigidbody.position;

        public void OnFixedUpdate(float delta)
        {
            if (_isMovedByVelocity == true)
                return;

            foreach (var interaction in _interactions)
            {
                switch (interaction)
                {
                    case PhysicsInteraction.Move:
                        var move = _moves.Dequeue();
                        _currentPosition = _moveCaster.ProcessMove(_currentPosition, move.Direction, move.Distance);

                        _logger.OnMoveProcessed(move.Direction, move.Distance, _currentPosition);
                        break;
                    case PhysicsInteraction.Teleport:
                        _currentPosition = _teleports.Dequeue();

                        _logger.OnPositionSet(_currentPosition);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _rigidbody.position = _currentPosition;

            _interactions.Clear();
        }

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }

        public void SetPosition(Vector2 position)
        {
            _teleports.Enqueue(position);
            _interactions.Enqueue(PhysicsInteraction.Teleport);
        }

        public void Move(Vector2 direction, float distance)
        {
            var move = new PhysicsMove(direction, distance);

            _moves.Enqueue(move);
            _interactions.Enqueue(PhysicsInteraction.Move);

            _logger.OnMoveEnqueued(direction, distance);
        }

        public void SetVelocity(Vector2 direction, float force)
        {
            direction.Normalize();
            _rigidbody.velocity = direction * force;

            _isMovedByVelocity = true;
        }

        public void ResetVelocity()
        {
            _currentPosition = _rigidbody.position;
            _rigidbody.velocity = Vector2.zero;
            _isMovedByVelocity = false;
        }

        private Vector2 ProcessMove(Vector2 direction, float distance)
        {
            var resultPosition = _currentPosition;

            if (Mathf.Approximately(direction.x, 0f) == false)
            {
                var xPosition = _currentPosition;
                xPosition.x += direction.x * distance;

                var resultX = Physics2D.CircleCastNonAlloc(
                    xPosition,
                    _collider.radius,
                    direction,
                    _buffer,
                    distance,
                    _collideMask);

                if (resultX == 0)
                {
                    resultPosition.x += direction.x * distance;
                }
                else
                {
                    var resultCenterX = Physics2D.CircleCastNonAlloc(
                        _currentPosition,
                        _collider.radius,
                        direction,
                        _buffer,
                        distance,
                        _collideMask);

                    if (resultCenterX != 0)
                    {
                        var overlapDistance = _buffer[0].distance;

                        if (Mathf.Approximately(overlapDistance, 0f) == true)
                        {
                            var colliderDistance = _buffer[0].collider.Distance(_collider);

                            overlapDistance = colliderDistance.distance;
                        }

                        resultPosition.x += direction.x * overlapDistance;
                    }
                }
            }

            if (Mathf.Approximately(direction.y, 0f) == false)
            {
                var yPosition = resultPosition;
                yPosition.y += direction.y * distance;

                var resultY = Physics2D.CircleCastNonAlloc(
                    yPosition,
                    _collider.radius,
                    direction,
                    _buffer,
                    distance,
                    _collideMask);

                if (resultY == 0)
                {
                    resultPosition.y += direction.y * distance;
                }
                else
                {
                    var resultCenterY = Physics2D.CircleCastNonAlloc(
                        _currentPosition,
                        _collider.radius,
                        direction,
                        _buffer,
                        distance,
                        _collideMask);

                    if (resultCenterY != 0)
                    {
                        var overlapDistance = _buffer[0].distance;

                        if (Mathf.Approximately(overlapDistance, 0f) == true)
                        {
                            var colliderDistance = _buffer[0].collider.Distance(_collider);

                            overlapDistance = colliderDistance.distance;
                        }

                        resultPosition.y += direction.y * overlapDistance;
                    }
                }
            }

            return resultPosition;
        }
    }
}