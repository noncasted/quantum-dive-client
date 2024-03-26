using System;
using System.Collections.Generic;
using GamePlay.Enemy.Entity.Views.RigidBodies.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Runtime
{
    public class EnemyRigidBody : 
        IEnemyRigidBody,
        IEntitySwitchListener,
        IFixedUpdatable
    {
        public EnemyRigidBody(
            Rigidbody2D rigidbody,
            MoveCaster caster,
            IUpdater updater)
        {
            _rigidbody = rigidbody;
            _caster = caster;
            _updater = updater;
        }
        
        private readonly Rigidbody2D _rigidbody;
        
        private readonly MoveCaster _caster;
        private readonly IUpdater _updater;

        private readonly RaycastHit2D[] _buffer = new RaycastHit2D[1];
        private readonly Queue<PhysicsInteraction> _interactions = new();

        private readonly Queue<PhysicsMove> _moves = new();
        private readonly Queue<Vector2> _teleports = new();

        private bool _isMovedByVelocity;
        private bool _isActive;

        private Vector2 _currentPosition;

        public Vector2 Position => _rigidbody.position;

        public void OnFixedUpdate(float delta)
        {
            if (_isMovedByVelocity == true)
                return;
            
            if (_isActive == false)
                return;

            foreach (var interaction in _interactions)
            {
                switch (interaction)
                {
                    case PhysicsInteraction.Move:
                        var move = _moves.Dequeue();
                        _currentPosition = _caster.ProcessMove(_currentPosition, move.Direction, move.Distance);
                        break;
                    case PhysicsInteraction.Teleport:
                        _currentPosition = _teleports.Dequeue();
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

        public void Enable()
        {
            _currentPosition = _rigidbody.position;
            _isActive = true;
        }

        public void Disable()
        {
            _isActive = false;
        }
    }
}