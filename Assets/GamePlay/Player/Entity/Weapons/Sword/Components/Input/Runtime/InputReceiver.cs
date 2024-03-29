﻿using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Abstract;
using Global.Inputs.View.Implementations.Combat.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Input.Runtime
{
    public class InputReceiver : IInputReceiver, IEntitySwitchLifetimeListener
    {
        public InputReceiver(ICombatInput input)
        {
            _input = input;
        }

        private readonly ICombatInput _input;

        private bool _isPerformed;

        public bool IsPerformed => _isPerformed;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _input.MeleeAttackPerformed.Listen(lifetime, OnPerformed);
            _input.MeleeAttackCanceled.Listen(lifetime, OnCanceled);
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