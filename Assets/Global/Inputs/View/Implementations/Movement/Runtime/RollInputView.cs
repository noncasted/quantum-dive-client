using Common.DataTypes.Runtime.Reactive;
using Common.DataTypes.Runtime.Structs;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Movement.Runtime
{
    public class RollInputView : IRollInputView, IInputConstructListener
    {
        public RollInputView(
            IInputConstraintsStorage constraintsStorage,
            Controls.GamePlayActions gamePlay)
        {
            _constraintsStorage = constraintsStorage;
            _gamePlay = gamePlay;
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly Controls.GamePlayActions _gamePlay;

        private readonly ViewableDelegate _performed = new();
        private readonly ViewableDelegate _canceled = new();

        public IViewableDelegate Performed => _performed;
        public IViewableDelegate Canceled => _canceled;

        public void OnInputConstructed(IReadOnlyLifetime lifetime)
        {
            _gamePlay.Roll.Listen(lifetime, OnPerformed, OnCanceled);
        }

        private void OnPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.RollInput] == true)
            {
                _canceled?.Invoke();
                return;
            }

            _performed.Invoke();
        }

        private void OnCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.RollInput] == true)
                return;

            _canceled.Invoke();
        }
    }
}