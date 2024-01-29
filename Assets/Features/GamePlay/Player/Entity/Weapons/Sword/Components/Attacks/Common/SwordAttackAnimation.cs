using System;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common
{       
    public class SwordAttackAnimation : AsyncRotatableAnimation
    {
        public SwordAttackAnimation(
            RotatableFrameProvider frameProvider,
            AnimationData data,
            PlayerSwordAttackEvent attackEvent) : base(frameProvider, data)
        {
            AddEventListener(attackEvent, OnAttackFrame);
        }

        public event Action Attack;

        private void OnAttackFrame()
        {
            Attack?.Invoke();
        }
    }
}       