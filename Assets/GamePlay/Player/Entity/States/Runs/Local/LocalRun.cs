using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.DataTypes.Structs;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.States.Runs.Logs;
using GamePlay.Player.Entity.Views.Physics.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    public class LocalRun : IPlayerLocalState, IPreFixedUpdatable, IEntitySwitchLifetimeListener, IFloatingTransition
    {
        public LocalRun(
            ILocalStateMachine stateMachine,
            IPlayerPhysics playerPhysics,
            IUpdater updater,
            IRunConfig runConfig,
            IEnhancedAnimator playerAnimator,
            IRunInput input,
            IFloatingTransitionsRegistry floatingTransitionsRegistry,
            IAnimation animation,
            RunDefinition definition,
            RunLogger logger)
        {
            _stateMachine = stateMachine;
            _playerPhysics = playerPhysics;
            _updater = updater;
            _runConfig = runConfig;

            _playerAnimator = playerAnimator;
            _animation = animation;
            _input = input;
            _floatingTransitionsRegistry = floatingTransitionsRegistry;

            Definition = definition;
            _logger = logger;
        }

        private readonly IAnimation _animation;
        private readonly IEnhancedAnimator _playerAnimator;

        private readonly RunLogger _logger;
        private readonly IPlayerPhysics _playerPhysics;
        private readonly IRunConfig _runConfig;

        private readonly IRunInput _input;
        private readonly IFloatingTransitionsRegistry _floatingTransitionsRegistry;

        private readonly ILocalStateMachine _stateMachine;
        private readonly IUpdater _updater;

        private bool _isStarted;

        public PlayerStateDefinition Definition { get; }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _input.Performed.Listen(lifetime, OnPerformed);
            _input.Canceled.Listen(lifetime, OnCanceled);
            
            _floatingTransitionsRegistry.Register(lifetime, Definition, this);
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

            _playerPhysics.LockCurrentRotation();
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

            _playerPhysics.SetForwardVelocity(_runConfig.Speed * delta);
            _playerPhysics.Rotate(new Vector2(_input.Direction.x * -1f, _input.Direction.y));
        }
    }
}