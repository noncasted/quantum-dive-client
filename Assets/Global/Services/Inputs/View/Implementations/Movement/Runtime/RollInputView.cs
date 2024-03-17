using Common.DataTypes.Reactive;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Global.Inputs.View.Logs;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Movement.Runtime
{
    public class RollInputView : IRollInputView, IInputConstructListener
    {
        public RollInputView(
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

        private readonly IViewableDelegate _performed = new ViewableDelegate();
        private readonly IViewableDelegate _canceled = new ViewableDelegate();

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
                Canceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.RollInput);
                return;
            }

            _logger.OnRollPressed();

            Performed.Invoke();
        }

        private void OnCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.RollInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.RollInput);
                return;
            }

            _logger.OnRollCanceled();

            Canceled.Invoke();
        }
    }
}