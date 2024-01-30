using System;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using GamePlay.Player.Entity.States.Runs.Logs;
using GamePlay.Player.Entity.States.Runs.Remote;
using Global.Inputs.View.Implementations.Movement;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    public class RunInput : IEntitySwitchListener, IRunInput
    {
        public RunInput(
            IMovementInputView inputView,
            IRunInputSync sync,
            RunLogger logger)
        {
            _inputView = inputView;
            _sync = sync;
            _logger = logger;
        }

        private readonly IMovementInputView _inputView;
        private readonly IRunInputSync _sync;
        private readonly RunLogger _logger;

        private Vector2 _direction;
        private bool _hasInput;
        
        public event Action Performed;
        public event Action Canceled;

        public Vector2 Direction => _direction;
        public bool HasInput => _hasInput;

        public void OnEnabled()
        {
            _inputView.MovementPerformed += OnInputView;
            _inputView.MovementCanceled += OnCanceled;
        }

        public void OnDisabled()
        {
            _inputView.MovementPerformed -= OnInputView;
            _inputView.MovementCanceled -= OnCanceled;
        }

        private void OnInputView(Vector2 direction)
        {
            _logger.OnInput(direction);

            _direction = direction;
            _sync.OnInput(direction);
            _hasInput = true;
            
            Performed?.Invoke();
        }

        private void OnCanceled()
        {
            _logger.OnCanceled();

            _direction = Vector2.zero;
            _sync.OnInput(_direction);
            _hasInput = false;
            
            Canceled?.Invoke();
        }
    }
}