using Common.DataTypes.Runtime.Reactive;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Implementations.Combat.Abstract;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Combat.Runtime
{
    public class CombatInput : ICombatInput, IInputConstructListener
    {
        public CombatInput(
            IInputConstraintsStorage constraintsStorage,
            IInputActions actions,
            Controls.GamePlayActions gamePlay)
        {
            _constraintsStorage = constraintsStorage;
            _actions = actions;
            _gamePlay = gamePlay;
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly IInputActions _actions;
        private readonly Controls.GamePlayActions _gamePlay;

        private readonly ViewableDelegate _rangeAttackPerformed = new();
        private readonly ViewableDelegate _rangeAttackCanceled = new();
        private readonly ViewableDelegate _meleeAttackPerformed = new();
        private readonly ViewableDelegate _meleeAttackCanceled = new();

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
                _rangeAttackCanceled?.Invoke();
                return;
            }

            _actions.Add(InvokeRangePerformed);
        }

        private void OnRangeAttackCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.AttackInput] == true)
            {
                return;
            }

            _actions.Add(InvokeRangeCanceled);
        }

        private void InvokeRangePerformed()
        {
            _rangeAttackPerformed?.Invoke();
        }

        private void InvokeRangeCanceled()
        {
            _rangeAttackCanceled?.Invoke();
        }

        private void OnMeleeAttackPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MeleeInput] == true)
            {
                _meleeAttackCanceled?.Invoke();
                return;
            }

            _actions.Add(InvokeMeleePerformed);
        }

        private void OnMeleeAttackCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MeleeInput] == true)
                return;

            _actions.Add(InvokeMeleeCanceled);
        }

        private void InvokeMeleePerformed()
        {
            _meleeAttackPerformed?.Invoke();
        }

        private void InvokeMeleeCanceled()
        {
            _meleeAttackCanceled?.Invoke();
        }
    }
}