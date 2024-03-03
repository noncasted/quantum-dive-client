﻿using Common.Architecture.Scopes.Runtime.Callbacks;
using GamePlay.Visuals.Cameras.Abstract;
using GamePlay.Visuals.Cameras.Logs;
using Global.Cameras.CurrentProvider.Runtime;
using Global.Inputs.Utils.Runtime.Projection;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Visuals.Cameras.Runtime
{
    public class LevelCamera :
        ILevelCamera,
        IPostFixedUpdatable,
        IScopeAwakeListener,
        IScopeSwitchListener
    {
        public LevelCamera(
            LevelCameraView camera,
            ICurrentCameraProvider currentCamera,
            IUpdater updater,
            LevelCameraLogger logger)
        {
            _camera = camera.Camera;
            _updater = updater;
            _logger = logger;
            _currentCamera = currentCamera;
            _transform = camera.transform;
        }

        private const float _offsetZ = -10f;

        private readonly Camera _camera;
        private readonly Transform _transform;

        private readonly ICurrentCameraProvider _currentCamera;
        private readonly IUpdater _updater;

        private readonly LevelCameraLogger _logger;

        private IFollowTarget _target;

        public Camera Camera => _camera;

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }

        public void StartFollow(Transform target)
        {
        }

        public void StartFollow(IFollowTarget target)
        {
            _target = target;

            _logger.OnStartFollow();
        }

        public void StopFollow()
        {
            if (_target == null)
            {
                _logger.OnStopFollowError();
                return;
            }

            _logger.OnStopFollow();

            _target = null;
        }

        public void Teleport(Vector2 target)
        {
            var position = new Vector3(target.x, target.y, _offsetZ);
            _transform.position = position;

            _logger.OnTeleport(position);
        }

        public void SetSize(float size)
        {
            _camera.orthographicSize = size;
        }

        public void OnAwake()
        {
            _currentCamera.SetCamera(_camera);
        }

        public void OnPostFixedUpdate(float delta)
        {
            if (_target == null)
                return;

            var source = _target.Position;
            var transform = _camera.transform;

            var direction = Quaternion.Euler(_target.XAngle, _target.YAngle, 0f) * Vector3.forward;
            var targetPosition = source + direction * _target.Distance;
            var targetRotation = Quaternion.LookRotation(direction * -1f, Vector3.up);

            var resultPosition = Vector3.Lerp(transform.position, targetPosition, delta * _target.MoveSpeed);
            var resultRotation = Quaternion.Lerp(transform.rotation, targetRotation, delta * _target.RotationSpeed);

            transform.position = resultPosition;
            transform.rotation = resultRotation;
        }
    }
}