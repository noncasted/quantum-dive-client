using Common.DataTypes.Runtime.Structs;
using GamePlay.Player.Entity.Views.Physics.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    public class PlayerPhysics : IPlayerPhysics, IPreFixedUpdatable, IEntitySwitchLifetimeListener
    {
        public PlayerPhysics(
            IUpdater updater,
            PlayerPhysicsView view,
            PlayerPhysicsConfig config)
        {
            _updater = updater;
            _view = view;
            _config = config;
        }

        private readonly IUpdater _updater;
        private readonly PlayerPhysicsView _view;
        private readonly PlayerPhysicsConfig _config;

        private Quaternion _targetDirection;

        public Vector3 Position => _view.position;
        public Vector3 Rotation => _view.rotation.eulerAngles;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
        }

        public void SetPosition(Vector3 position)
        {
            _view.SetPosition(position);

        }

        public void Move(Vector2 direction, float distance)
        {
            var convertedDirection = new Vector3(direction.normalized.x, 0f, direction.normalized.y);
            var position = _view.position + convertedDirection * distance;

            _view.SetPosition(position);
        }

        public void SetVelocity(Vector2 direction, float force)
        {
            var convertedDirection = new Vector3(direction.normalized.x, 0f, direction.normalized.y);
            var velocity = convertedDirection * force;

            _view.SetVelocity(velocity);
        }

        public void SetForwardVelocity(float force)
        {
            var direction = _view.transform.forward;
            var position = _view.position + direction * force;

            _view.SetPosition(position);
        }

        public void LockCurrentRotation()
        {
            _targetDirection = _view.rotation;
        }

        public void Rotate(Vector2 direction)
        {
            _targetDirection = Quaternion.Euler(0f, direction.ToAngle(), 0f);
        }

        public void Rotate(float angle)
        {
            _targetDirection = Quaternion.Euler(0f, angle, 0f);
        }

        public void ResetVelocity()
        {
            _view.SetVelocity(Vector3.zero);
        }

        public void OnPreFixedUpdate(float delta)
        {
            var rotationSpeed = _config.RotationSpeed;
            var resultRotation = Quaternion.Lerp(_view.rotation, _targetDirection, delta * rotationSpeed);

            _view.SetRotation(resultRotation);
        }
    }
}