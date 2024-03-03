using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.Architecture.Lifetimes.Viewables;
using GamePlay.Player.Entity.States.Runs.Logs;
using GamePlay.Player.Entity.States.Runs.Remote;
using Global.Inputs.View.Implementations.Movement;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    public class RunInput : IEntitySwitchLifetimeListener, IRunInput
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

        private readonly IViewableDelegate _performed = new ViewableDelegate();
        private readonly IViewableDelegate _canceled = new ViewableDelegate();

        public IViewableDelegate Performed => _performed;
        public IViewableDelegate Canceled => _canceled;

        public Vector2 Direction => _direction;
        public bool HasInput => _hasInput;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _inputView.Performed.Listen(lifetime, OnInputView);
            _inputView.Canceled.Listen(lifetime, OnCanceled);
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