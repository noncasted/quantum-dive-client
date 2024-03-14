using System;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Runs.Local;
using GamePlay.Player.Entity.States.SubStates.Movement.Abstract;
using GamePlay.Player.Entity.Views.Physics.Abstract;
using Global.System.Updaters.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Movement.Runtime
{
    public class SubMovement : ISubMovement, IPreFixedUpdatable
    {
        public SubMovement(
            IPlayerPhysics playerPhysics,
            IUpdater updater,
            IEnhancedAnimator animator,
            IRunInput input,
            IAnimation runAnimation,
            IAnimation walkAnimation,
            IAnimation idleAnimation)
        {
            _playerPhysics = playerPhysics;
            _updater = updater;

            _animator = animator;
            _input = input;
            
            _runAnimation = runAnimation;
            _walkAnimation = walkAnimation;
            _idleAnimation = idleAnimation;
        }

        private readonly IEnhancedAnimator _animator;
        private readonly IPlayerPhysics _playerPhysics;
        private readonly IRunInput _input;
        private readonly IUpdater _updater;
        
        private readonly IAnimation _runAnimation;
        private readonly IAnimation _walkAnimation;
        private readonly IAnimation _idleAnimation;

        private bool _playAnimations;
        private bool _isEntered;
        private float _speed;
        private MovementState _state;
        private MoveType _moveType;

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
               // _currentFrameProvider = _idleAnimation.FrameProvider;
            }

            _state = MovementState.Idle;
            _playerPhysics.ResetVelocity();
        }

        private void Run(float delta)
        {
            if (_state != MovementState.Run && _playAnimations == true)
            {
                switch (_moveType)
                {
                    case MoveType.Run:
                        _animator.PlayLooped(_runAnimation);
                      //  _currentFrameProvider = _runAnimation.FrameProvider;

                        break;
                    case MoveType.Walk:
                        _animator.PlayLooped(_walkAnimation);
                      //  _currentFrameProvider = _walkAnimation.FrameProvider;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _state = MovementState.Run;
            _playerPhysics.Move(_input.Direction, _speed * delta);
        }
    }
}