using Common.DataTypes.Runtime.Reactive;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Movement.Runtime
{
    public class MovementInputView : IMovementInputView, IInputConstructListener
    {
        public MovementInputView(
            IInputConstraintsStorage constraintsStorage,
            Controls.GamePlayActions gamePlay)
        {
            _constraintsStorage = constraintsStorage;
            _gamePlay = gamePlay;
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly Controls.GamePlayActions _gamePlay;

        private readonly ViewableDelegate<Vector2> _performed = new();
        private readonly ViewableDelegate _canceled = new();

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
                _canceled?.Invoke();
                return;
            }

            var value = context.ReadValue<Vector2>();

            _performed.Invoke(value);
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MovementInput] == true)
                return;

            _canceled.Invoke();
        }
    }
}