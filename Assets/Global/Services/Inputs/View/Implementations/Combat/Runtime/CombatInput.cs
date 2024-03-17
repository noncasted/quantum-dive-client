using Common.DataTypes.Reactive;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Implementations.Combat.Abstract;
using Global.Inputs.View.Logs;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Combat.Runtime
{
    public class CombatInput : ICombatInput, IInputConstructListener
    {
        public CombatInput(
            IInputConstraintsStorage constraintsStorage,
            IInputActions actions,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _actions = actions;
            _gamePlay = gamePlay;
            _logger = logger;
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly IInputActions _actions;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;

        private readonly IViewableDelegate _rangeAttackPerformed = new ViewableDelegate();
        private readonly IViewableDelegate _rangeAttackCanceled = new ViewableDelegate();
        private readonly IViewableDelegate _meleeAttackPerformed = new ViewableDelegate();
        private readonly IViewableDelegate _meleeAttackCanceled = new ViewableDelegate();

        public IViewableDelegate RangeAttackPerformed => _rangeAttackPerformed;
        public IViewableDelegate RangeAttackCanceled => _rangeAttackCanceled;
        public IViewableDelegate MeleeAttackPerformed => _meleeAttackPerformed;
        public IViewableDelegate MeleeAttackCanceled => _meleeAttackCanceled;

        public void OnInputConstructed(IReadOnlyLifetime lifetime)
        {
            _gamePlay.RangeAttack.Listen(lifetime, OnRangeAttackPerformed, OnRangeAttackCanceled);
            _gamePlay.MeleeAttack.Listen(lifetime, OnMeleeAttackPerformed, OnMeleeAttackCanceled);
        }

        private void OnRangeAttackPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.AttackInput] == true)
            {
                RangeAttackCanceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.AttackInput);
                return;
            }

            _logger.OnRangeAttackPerformed();

            _actions.Add(InvokeRangePerformed);
        }

        private void OnRangeAttackCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.AttackInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.AttackInput);
                return;
            }

            _logger.OnRangeAttackCanceled();

            _actions.Add(InvokeRangeCanceled);
        }

        private void InvokeRangePerformed()
        {
            RangeAttackPerformed?.Invoke();
        }

        private void InvokeRangeCanceled()
        {
            RangeAttackCanceled?.Invoke();
        }

        private void OnMeleeAttackPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MeleeInput] == true)
            {
                MeleeAttackCanceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.MeleeInput);
                return;
            }

            _logger.OnMeleeAttackPerformed();

            _actions.Add(InvokeMeleePerformed);
        }

        private void OnMeleeAttackCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MeleeInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.MeleeInput);
                return;
            }

            _logger.OnMeleeAttackCanceled();

            _actions.Add(InvokeMeleeCanceled);
        }

        private void InvokeMeleePerformed()
        {
            MeleeAttackPerformed?.Invoke();
        }

        private void InvokeMeleeCanceled()
        {
            MeleeAttackCanceled?.Invoke();
        }
    }
}