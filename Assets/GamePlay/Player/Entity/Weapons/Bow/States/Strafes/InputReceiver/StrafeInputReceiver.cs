using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Global.Inputs.View.Implementations.Combat;
using Global.Inputs.View.Implementations.Movement;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver
{
    public class StrafeInputReceiver : IEntitySwitchLifetimeListener, IStrafeInputReceiver
    {
        public StrafeInputReceiver(IMovementInputView movement, ICombatInput combat)
        {
            _movement = movement;
            _combat = combat;
        }
        
        private readonly IMovementInputView _movement;
        private readonly ICombatInput _combat;

        private bool _isMovementPerformed;
        private bool _isShootPerformed;

        private Vector2 _direction;

        public bool IsPerformed => CheckPerform();
        public Vector2 Direction => _direction; 
        
        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _movement.Performed.Listen(lifetime, OnMovementPerformed);
            _movement.Canceled.Listen(lifetime, OnMovementCanceled);
            _combat.RangeAttackPerformed.Listen(lifetime, OnShootPerformed);
            _combat.RangeAttackCanceled.Listen(lifetime, OnShootCanceled);            
        }

        private void OnMovementPerformed(Vector2 direction)
        {
            _isMovementPerformed = true;

            _direction = direction;
        }

        private void OnMovementCanceled()
        {
            _isMovementPerformed = false;
        }

        private void OnShootPerformed()
        {
            _isShootPerformed = true;
        }

        private void OnShootCanceled()
        {
            _isShootPerformed = false;
        }

        private bool CheckPerform()
        {
            if (_isMovementPerformed == false)
                return false;

            if (_isShootPerformed == false)
                return false;

            return true;
        }
    }
}