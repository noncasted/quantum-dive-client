using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Abstract;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.Views.Physics.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
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
            RunDefinition definition)
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
        }

        private readonly IAnimation _animation;
        private readonly IEnhancedAnimator _playerAnimator;

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
                return;
            }

            Begin();
        }

        private void OnPerformed()
        {
            if (_isStarted == true)
                return;

            if (_stateMachine.IsAvailable(Definition) == false)
                return;

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
            _playerPhysics.Rotate(new Vector2(_input.Direction.x, _input.Direction.y * -1));
        }
    }
}