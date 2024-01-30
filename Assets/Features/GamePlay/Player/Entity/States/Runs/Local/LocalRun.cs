using Common.Architecture.Entities.Runtime.Callbacks;
using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.States.Runs.Logs;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.RigidBodies.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    public class LocalRun : IPlayerLocalState, IPreFixedUpdatable, IEntitySwitchListener, IFloatingTransition
    {
        public LocalRun(
            ILocalStateMachine stateMachine,
            IPlayerRigidBody playerRigidBody,
            IUpdater updater,
            IRunConfig runConfig,
            IPlayerAnimator playerAnimator,
            IPlayerSpriteFlip spriteFlip,
            IRunInput input,
            IFloatingTransitionsRegistry floatingTransitionsRegistry,
            RunAnimation animation,
            RunDefinition definition,
            RunLogger logger)
        {
            _stateMachine = stateMachine;
            _playerRigidBody = playerRigidBody;
            _updater = updater;
            _runConfig = runConfig;

            _playerAnimator = playerAnimator;
            _spriteFlip = spriteFlip;
            _animation = animation;
            _input = input;
            _floatingTransitionsRegistry = floatingTransitionsRegistry;

            Definition = definition;
            _logger = logger;
        }

        private readonly RunAnimation _animation;
        private readonly IPlayerAnimator _playerAnimator;
        private readonly IPlayerSpriteFlip _spriteFlip;

        private readonly RunLogger _logger;
        private readonly IPlayerRigidBody _playerRigidBody;
        private readonly IRunConfig _runConfig;

        private readonly IRunInput _input;
        private readonly IFloatingTransitionsRegistry _floatingTransitionsRegistry;

        private readonly ILocalStateMachine _stateMachine;
        private readonly IUpdater _updater;

        private bool _isStarted;

        public PlayerStateDefinition Definition { get; }

        public void OnEnabled()
        {
            _input.Performed += OnPerformed;
            _input.Canceled += OnCanceled;

            _floatingTransitionsRegistry.Register(Definition, this);
        }

        public void OnDisabled()
        {
            _input.Performed -= OnPerformed;
            _input.Canceled -= OnCanceled;
            
            _floatingTransitionsRegistry.Unregister(Definition);
        }
        
        public bool IsTransitionFromFloatingAvailable()
        {
            return _input.HasInput;
        }

        public void EnterFromFloating()
        {
            if (_input.Direction == Vector2.zero)
            {
                _logger.OnEnterFromFloatingError();
                return;
            }

            _logger.OnEnteredFromFloating(_input.Direction);

            Begin();
        }
        
        private void OnPerformed()
        {
            if (_isStarted == true)
                return;

            if (_stateMachine.IsAvailable(Definition) == false)
                return;

            _logger.OnEnteredOnTrigger(_input.Direction);

            Begin();
        }

        private void OnCanceled()
        {
            if (_isStarted == false)
                return;

            _stateMachine.Exit(this);
        }

        public void Break()
        {
            if (_isStarted == false)
                return;

            _isStarted = false;

            _updater.Remove(this);

            _logger.OnBroke();
        }

        private void Begin()
        {
            if (_isStarted == true)
                return;

            _playerAnimator.PlayLooped(_animation);

            _isStarted = true;
            _stateMachine.Enter(this);
            _updater.Add(this);
        }

        public void OnPreFixedUpdate(float delta)
        {
            if (_isStarted == false)
                Debug.LogError("Not started");

            var angle = _input.Direction.ToAngle();
            
            _animation.SetOrientation(angle.ToOrientation());
            _spriteFlip.FlipAlong(angle);
            
            _playerRigidBody.Move(_input.Direction, _runConfig.Speed * delta);
        }
    }
}