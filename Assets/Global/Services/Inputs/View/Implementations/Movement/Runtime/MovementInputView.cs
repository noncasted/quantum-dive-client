using Common.DataTypes.Reactive;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.Constranits.Runtime;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Sources;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Movement
{
    public class MovementInputView : IMovementInputView, IInputSource
    {
        public MovementInputView(
            IInputConstraintsStorage constraintsStorage,
            IInputSourcesHandler sourcesHandler,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _gamePlay = gamePlay;
            _logger = logger;
            
            sourcesHandler.AddListener(this);
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;

        private readonly IViewableDelegate<Vector2> _performed = new ViewableDelegate<Vector2>();
        private readonly IViewableDelegate _canceled = new ViewableDelegate();

        public IViewableDelegate<Vector2> Performed => _performed;
        public IViewableDelegate Canceled => _canceled;
        
        public void Listen()
        {
            _gamePlay.Movement.performed += OnMovementPerformed;
            _gamePlay.Movement.canceled += OnMovementCanceled;
        }

        public void Dispose()
        {
            _gamePlay.Movement.performed -= OnMovementPerformed;
            _gamePlay.Movement.canceled -= OnMovementCanceled;
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MovementInput] == true)
            {
                Canceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.MovementInput);
                return;
            }

            var value = context.ReadValue<Vector2>();

            _logger.OnMovementPressed(value);

            Performed.Invoke(value);
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MovementInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.MovementInput);
                return;
            }

            _logger.OnMovementCanceled();

            Canceled.Invoke();
        }
    }
}