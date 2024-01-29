using System;
using GamePlay.Player.Entity.Components.Rotations.Animation;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using GamePlay.Player.Entity.States.Idles.Common;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.States.Runs.Local;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.RigidBodies.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Movement.Runtime
{
    public class SubMovement : ISubMovement, IPreFixedUpdatable
    {
        public SubMovement(
            IPlayerRigidBody playerRigidBody,
            IUpdater updater,
            IPlayerAnimator animator,
            IRunInput input,
            RunAnimation runAnimation,
            WalkAnimation walkAnimation,
            IdleAnimation idleAnimation)
        {
            _playerRigidBody = playerRigidBody;
            _updater = updater;

            _animator = animator;
            _input = input;
            
            _runAnimation = runAnimation;
            _walkAnimation = walkAnimation;
            _idleAnimation = idleAnimation;
        }

        private readonly IPlayerAnimator _animator;
        private readonly IPlayerRigidBody _playerRigidBody;
        private readonly IRunInput _input;
        private readonly IUpdater _updater;
        
        private readonly RunAnimation _runAnimation;
        private readonly WalkAnimation _walkAnimation;
        private readonly IdleAnimation _idleAnimation;

        private bool _playAnimations;
        private bool _isEntered;
        private float _speed;
        private MovementState _state;
        private MoveType _moveType;
        private IRotatableFrameProvider _currentFrameProvider;

        public void Enter(bool playAnimations, float speed, MoveType moveType)
        {
            _moveType = moveType;
            _speed = speed;
            
            if (_isEntered == true)
            {
                Debug.LogError("Can't true subMovement twice");
                return;
            }
            
            _playAnimations = playAnimations;
            _state = MovementState.None;
            _isEntered = true;

            _updater.Add(this);
        }

        public void Exit()
        {
            if (_isEntered == false)
            {
                Debug.LogError("Can't exit subMovement twice");
                return;
            }

            _isEntered = false;
            _updater.Remove(this);
        }

        public void SetAnimationRotation(PlayerOrientation orientation)
        {
            _currentFrameProvider?.SetOrientation(orientation);
        }

        public void OnPreFixedUpdate(float delta)
        {
            if (_input.HasInput == true)
                Run(delta);
            else
                Idle();
        }

        private void Idle()
        {
            if (_state != MovementState.Idle && _playAnimations == true)
            {
                _animator.PlayLooped(_idleAnimation);
                _currentFrameProvider = _idleAnimation.FrameProvider;
            }

            _state = MovementState.Idle;
            _playerRigidBody.ResetVelocity();
        }

        private void Run(float delta)
        {
            if (_state != MovementState.Run && _playAnimations == true)
            {
                switch (_moveType)
                {
                    case MoveType.Run:
                        _animator.PlayLooped(_runAnimation);
                        _currentFrameProvider = _runAnimation.FrameProvider;

                        break;
                    case MoveType.Walk:
                        _animator.PlayLooped(_walkAnimation);
                        _currentFrameProvider = _walkAnimation.FrameProvider;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _state = MovementState.Run;
            _playerRigidBody.Move(_input.Direction, _speed * delta);
        }
    }
}