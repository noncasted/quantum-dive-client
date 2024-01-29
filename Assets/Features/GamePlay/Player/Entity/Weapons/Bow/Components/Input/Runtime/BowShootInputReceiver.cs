using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using Global.Inputs.View.Implementations.Combat;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime
{
    public class BowShootInputReceiver : IPlayerSwitchListener, IBowShootInputReceiver
    {
        public BowShootInputReceiver(ICombatInput input)
        {
            _input = input;
        }

        private readonly ICombatInput _input;

        private bool _isPerformed;

        public bool IsPerformed => _isPerformed;

        public void OnEnabled()
        {
            _input.RangeAttackPerformed += OnPerformed;
            _input.RangeAttackCanceled += OnCanceled;
        }

        public void OnDisabled()
        {
            _input.RangeAttackPerformed -= OnPerformed;
            _input.RangeAttackCanceled -= OnCanceled;
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