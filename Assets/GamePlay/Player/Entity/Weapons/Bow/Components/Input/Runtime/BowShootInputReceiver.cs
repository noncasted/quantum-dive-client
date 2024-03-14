﻿
using Internal.Scopes.Abstract.Lifetimes;
using Global.Inputs.View.Implementations.Combat;
using Internal.Scopes.Abstract.Instances.Entities;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime
{
    public class BowShootInputReceiver : IEntitySwitchLifetimeListener, IBowShootInputReceiver
    {
        public BowShootInputReceiver(ICombatInput input)
        {
            _input = input;
        }

        private readonly ICombatInput _input;

        private bool _isPerformed;

        public bool IsPerformed => _isPerformed;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _input.RangeAttackPerformed.Listen(lifetime, OnPerformed);
            _input.RangeAttackCanceled.Listen(lifetime, OnCanceled);
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