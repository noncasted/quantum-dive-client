using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using Global.Inputs.View.Implementations.Combat;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Input.Runtime
{
    public class InputReceiver : IInputReceiver, IPlayerSwitchListener
    {
        public InputReceiver(ICombatInput input)
        {
            _input = input;
        }

        private readonly ICombatInput _input;

        private bool _isPerformed;

        public bool IsPerformed => _isPerformed;

        public void OnEnabled()
        {
            _input.MeleeAttackPerformed += OnPerformed;
            _input.MeleeAttackCanceled += OnCanceled;
        }

        public void OnDisabled()
        {
            _input.MeleeAttackPerformed -= OnPerformed;
            _input.MeleeAttackCanceled -= OnCanceled;
        }

        private void OnPerformed()
        {
            _isPerformed = true;
        }

        private void OnCanceled()
        {
            _isPerformed = false;
        }
    }
}