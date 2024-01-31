using Common.Architecture.Lifetimes.Viewables;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.Constranits.Runtime;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Sources;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Movement
{
    public class RollInputView : IRollInputView, IInputSource
    {
        public RollInputView(
            IInputConstraintsStorage constraintsStorage,
            IInputSourcesHandler inputListenersHandler,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _gamePlay = gamePlay;
            _logger = logger;

            inputListenersHandler.AddListener(this);
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;

        private readonly IViewableDelegate _performed = new ViewableDelegate();
        private readonly IViewableDelegate _canceled = new ViewableDelegate();

        public IViewableDelegate Performed => _performed;
        public IViewableDelegate Canceled => _canceled;

        public void Listen()
        {
            _gamePlay.Roll.performed += OnPerformed;
            _gamePlay.Roll.canceled += OnCanceled;
        }

        public void Dispose()
        {
            _gamePlay.Roll.performed -= OnPerformed;
            _gamePlay.Roll.canceled -= OnCanceled;
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