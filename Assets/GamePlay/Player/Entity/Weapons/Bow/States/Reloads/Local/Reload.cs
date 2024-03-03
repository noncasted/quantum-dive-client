﻿using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Combo.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common.Animations;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Local
{
    public class Reload : IComboState, IPlayerLocalState, IUpdatable, IEntitySwitchLifetimeListener
    {
        public Reload(
            IBowShootInputReceiver inputReceiver,
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            IBowGameObject gameObject,
            IEnhancedAnimator playerAnimator,
            IBowAnimator bowAnimator,
            IRotation rotation,
            IBowArrow arrow,
            IProjectileStarterConfig config,

            BowReloadAnimation bowAnimation,
            PlayerReloadAnimation playerAnimation,

            IUpdater updater,
            
            BowReloadDefinition definition,
            PlayerStateDefinition[] transitions)
        {
            _inputReceiver = inputReceiver;
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _gameObject = gameObject;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _rotation = rotation;
            _arrow = arrow;
            _config = config;
            _updater = updater;
            _bowAnimation = bowAnimation;
            _playerAnimation = playerAnimation;
            Transitions = transitions;
            Definition = definition;
        }

        private readonly IBowShootInputReceiver _inputReceiver;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IBowGameObject _gameObject;

        private readonly IEnhancedAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IRotation _rotation;
        private readonly IBowArrow _arrow;
        private readonly IProjectileStarterConfig _config;
        private readonly IUpdater _updater;
        private readonly BowReloadAnimation _bowAnimation;
        private readonly PlayerReloadAnimation _playerAnimation;

        private CancellationTokenSource _cancellation;
        
        public PlayerStateDefinition[] Transitions { get; }
        public PlayerStateDefinition Definition { get; }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _comboStateMachine.Register(lifetime, Definition, this);
        }
        
        public bool IsTransitionToComboAvailable()
        {
            if (_inputReceiver.IsPerformed == false)
                return false;
            
            return true;
        }

        public void EnterCombo()
        {
            _stateMachine.Enter(this);
            _gameObject.Enable();

            _updater.Add(this);
            
            Process().Forget();
        }

        public void Break()
        {
            _updater.Remove(this);
            _gameObject.Disable();

            Cancel();
        }

        public void OnUpdate(float delta)
        {
            _playerAnimation.SetOrientation(_rotation.Orientation);
        }

        private async UniTask Process()
        {
            Cancel();

            _cancellation = new CancellationTokenSource();

            // var playerAnimationTask = _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);
            // var bowAnimationTask = _bowAnimator.PlayAsync(_bowAnimation, _cancellation.Token);
            //
            // _arrow.Show(_config.Data.Preview);
            //
            // await UniTask.WhenAll(tasks: new[] { playerAnimationTask, bowAnimationTask });

            _arrow.Hide();

            _comboStateMachine.TryTransitCombo(this, Transitions);
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}