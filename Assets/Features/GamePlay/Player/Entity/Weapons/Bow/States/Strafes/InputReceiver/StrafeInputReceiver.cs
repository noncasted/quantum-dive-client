using Common.Architecture.Entities.Common.DefaultCallbacks;
using Global.Inputs.View.Implementations.Combat;
using Global.Inputs.View.Implementations.Movement;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver
{
    public class StrafeInputReceiver : IEntitySwitchListener, IStrafeInputReceiver
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
        
        public void OnEnabled()
        {
            _movement.MovementPerformed += OnMovementPerformed;
            _movement.MovementCanceled += OnMovementCanceled;

            _combat.RangeAttackPerformed += OnShootPerformed;
            _combat.RangeAttackCanceled += OnShootCanceled;
        }

        public void OnDisabled()
        {
            _movement.MovementPerformed -= OnMovementPerformed;
            _movement.MovementCanceled -= OnMovementCanceled;

            _combat.RangeAttackPerformed -= OnShootPerformed;
            _combat.RangeAttackCanceled -= OnShootCanceled;
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