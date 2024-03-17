using Common.DataTypes.Reactive;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Global.Inputs.View.Logs;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Movement.Runtime
{
    public class MovementInputView : IMovementInputView, IInputConstructListener
    {
        public MovementInputView(
            IInputConstraintsStorage constraintsStorage,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _gamePlay = gamePlay;
            _logger = logger;
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;

        private readonly IViewableDelegate<Vector2> _performed = new ViewableDelegate<Vector2>();
        private readonly IViewableDelegate _canceled = new ViewableDelegate();

        public IViewableDelegate<Vector2> Performed => _performed;
        public IViewableDelegate Canceled => _canceled;

        public void OnInputConstructed(IReadOnlyLifetime lifetime)
        {
            _gamePlay.Movement.Listen(lifetime, OnMovementPerformed, OnMovementCanceled);
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