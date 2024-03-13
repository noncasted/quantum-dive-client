using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Views.Physics.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Runtime
{
    public class AngleSteering : IAngleSteering, IPreFixedUpdatable
    {
        public AngleSteering(
            IRotation rotation,
            IPlayerPhysics physics,
            IUpdater updater)
        {
            _rotation = rotation;
            _physics = physics;
            _updater = updater;
        }

        private readonly IRotation _rotation;
        private readonly IPlayerPhysics _physics;
        private readonly IUpdater _updater;

        private float _timer;
        private float _time;
        private float _startAngle;
        private bool _isActive;

        public void Start(float time)
        {
            if (_isActive == true)
                Debug.LogError("Angel steering overlap");

            _time = time;
            _timer = 0f;
            _startAngle = _rotation.Angle;
            _isActive = true;

            _updater.Add(this);
        }

        public void Stop()
        {
            if (_isActive == false)
                return;
            
            _updater.Remove(this);
            _isActive = false;
        }

        public void OnPreFixedUpdate(float delta)
        {
            var progress = _timer / _time;
            var targetAngle = Mathf.Lerp(_startAngle, _rotation.Angle, progress);
            _physics.Rotate(targetAngle);
            _timer += delta;
        }
    }
}