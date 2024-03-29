﻿using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Rotations.Local.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Abstract;
using GamePlay.Player.Entity.States.SubStates.Movement.Abstract;
using GamePlay.Player.Entity.Views.Animators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.Configuration;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Abstract;
using GamePlay.Services.Projectiles.Factory;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Free
{
    public class FreeShooter : IFloatingTransition, IPlayerLocalState, IEntitySwitchLifetimeListener, IUpdatable
    {
        public FreeShooter(
            IFloatingTransitionsRegistry floatingTransitionsRegistry,
            IProjectileStarter projectileStarter,
            IBowConfig config,
            IUpdater updater,
            IBowAnimator animator,
            IBowArrow arrow,
            IPlayerAnimator playerAnimator,
            IAnimation playerAnimation,
            IProjectileStarterConfig projectileConfig,
            IBowGameObject gameObject,
            IRotation playerRotation,
            ISubMovement subMovement,
            ILocalStateMachine stateMachine,
            IBowShootInputReceiver inputReceiver,
            ShootMoveConfig moveConfig,
            BowShootDefinition definition)
        {
            _floatingTransitionsRegistry = floatingTransitionsRegistry;
            _projectileStarter = projectileStarter;
            _config = config;
            _updater = updater;
            _animator = animator;
            _arrow = arrow;
            _playerAnimator = playerAnimator;
            _playerAnimation = playerAnimation;
            _projectileConfig = projectileConfig;
            _gameObject = gameObject;
            _playerRotation = playerRotation;
            _subMovement = subMovement;
            _stateMachine = stateMachine;
            _inputReceiver = inputReceiver;
            _moveConfig = moveConfig;
            Definition = definition;
        }

        private readonly IBowConfig _config;
        private readonly IFloatingTransitionsRegistry _floatingTransitionsRegistry;
        private readonly IProjectileStarter _projectileStarter;
        private readonly IUpdater _updater;
        private readonly IBowAnimator _animator;
        private readonly IBowArrow _arrow;
        private readonly IPlayerAnimator _playerAnimator;
        private readonly IAnimation _playerAnimation;
        private readonly IProjectileStarterConfig _projectileConfig;
        private readonly IBowGameObject _gameObject;
        private readonly IRotation _playerRotation;
        private readonly ISubMovement _subMovement;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IBowShootInputReceiver _inputReceiver;
        private readonly ShootMoveConfig _moveConfig;

        private bool _isProcessing;
        private float _lastShotTime;
        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }

        public bool IsTransitionFromFloatingAvailable()
        {
            if (Time.time < _lastShotTime + _config.ShotDelay.Value)
                return false;

            if (_inputReceiver.IsPerformed == false || _isProcessing == true)
                return false;

            return true;
        }

        public void EnterFromFloating()
        {
            Shoot().Forget();
        }

        public void Break()
        {
            Cancel();
            _isProcessing = false;

            _subMovement.Exit();
        }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _floatingTransitionsRegistry.Register(lifetime, Definition, this);
            _updater.Add(lifetime, this);
        }

        public void OnUpdate(float delta)
        {
            if (_isProcessing == true)
            {
            }

            if (IsTransitionFromFloatingAvailable() == false
                || _stateMachine.IsAvailable(Definition) == false)
                return;

            Shoot().Forget();
        }

        private async UniTask Shoot()
        {
            _stateMachine.Enter(this);

            _lastShotTime = Time.time;
            _isProcessing = true;

            Cancel();

            _cancellation = new CancellationTokenSource();

            _subMovement.Enter(true, _moveConfig.Speed, MoveType.Walk);
            _gameObject.Enable();

            await _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);

            var shootParams = new ShootParams(
                _config.Damage.Value,
                _config.PushForce.Value,
                _config.ArrowSpeed.Value,
                _projectileConfig.Scale,
                _projectileConfig.Radius);

            _projectileStarter.Shoot(0f, _projectileConfig.Data.Definition, shootParams);

            //await _animator.PlayShootAsync(_cancellation.Token);

            _isProcessing = false;

            _stateMachine.Exit(this);
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}