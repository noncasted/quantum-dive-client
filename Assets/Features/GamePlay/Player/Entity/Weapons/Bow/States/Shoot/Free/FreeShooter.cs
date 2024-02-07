using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;
using GamePlay.Combat.Projectiles.Factory;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.States.SubStates.Movement.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Configuration;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Starter;
using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Local;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Free
{
    public class FreeShooter : IFloatingTransition, IPlayerLocalState, IEntitySwitchLifetimeListener, IUpdatable
    {
        public FreeShooter(
            IFloatingTransitionsRegistry floatingTransitionsRegistry,
            IProjectileStarter projectileStarter,
            IBowRotation rotation,
            IBowConfig config,
            IUpdater updater,
            IBowAnimator animator,
            IBowArrow arrow,
            IProjectileStarterConfig projectileConfig,
            IBowGameObject gameObject,
            IRotation playerRotation,
            IPlayerSpriteFlip playerSpriteFlip,
            ISubMovement subMovement,
            ILocalStateMachine stateMachine,
            IBowShootInputReceiver inputReceiver,
            ShootMoveConfig moveConfig,
            BowShootDefinition definition)
        {
            _floatingTransitionsRegistry = floatingTransitionsRegistry;
            _projectileStarter = projectileStarter;
            _rotation = rotation;
            _config = config;
            _updater = updater;
            _animator = animator;
            _arrow = arrow;
            _projectileConfig = projectileConfig;
            _gameObject = gameObject;
            _playerRotation = playerRotation;
            _playerSpriteFlip = playerSpriteFlip;
            _subMovement = subMovement;
            _stateMachine = stateMachine;
            _inputReceiver = inputReceiver;
            _moveConfig = moveConfig;
            Definition = definition;
        }

        private readonly IBowRotation _rotation;
        private readonly IBowConfig _config;
        private readonly IFloatingTransitionsRegistry _floatingTransitionsRegistry;
        private readonly IProjectileStarter _projectileStarter;
        private readonly IUpdater _updater;
        private readonly IBowAnimator _animator;
        private readonly IBowArrow _arrow;
        private readonly IProjectileStarterConfig _projectileConfig;
        private readonly IBowGameObject _gameObject;
        private readonly IRotation _playerRotation;
        private readonly IPlayerSpriteFlip _playerSpriteFlip;
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
            _gameObject.Disable();
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
                var orientation = _playerRotation.Orientation;

                _subMovement.SetAnimationRotation(orientation);
                _playerSpriteFlip.FlipAlong(_playerRotation.Angle);
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

            //await _animator.PlayAimAsync(_cancellation.Token);

            var shootParams = new ShootParams(
                _config.Damage.Value,
                _config.PushForce.Value,
                _config.ArrowSpeed.Value,
                _projectileConfig.Scale,
                _projectileConfig.Radius);

            _projectileStarter.Shoot(_rotation.Angle, _projectileConfig.Data.Definition, shootParams);

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