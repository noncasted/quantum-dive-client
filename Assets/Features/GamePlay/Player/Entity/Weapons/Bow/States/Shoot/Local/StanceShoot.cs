using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;
using GamePlay.Combat.Projectiles.Factory;
using GamePlay.Player.Entity.Components.Combo.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Configuration;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Starter;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Local
{
    public class StanceShoot : IPlayerLocalState, IUpdatable, IComboState, IEntitySwitchLifetimeListener
    {
        public StanceShoot(
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            IBowConfig config,
            IProjectileStarter projectileStarter,
            IProjectileStarterConfig projectileConfig,
            
            IPlayerAnimator playerAnimator,
            IPlayerSpriteFlip spriteFlip,
            IRotation rotation,
            
            IBowAnimator bowAnimator,
            IBowGameObject bowGameObject,

            IUpdater updater,
            
            BowShootAnimation bowAnimation,
            PlayerShootAnimation playerAnimation,
            PlayerStateDefinition[] transitions,
            BowShootDefinition definition)
        {
            _projectileConfig = projectileConfig;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _spriteFlip = spriteFlip;
            _updater = updater;
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _config = config;
            _rotation = rotation;
            _bowGameObject = bowGameObject;
            _projectileStarter = projectileStarter;
            _bowAnimation = bowAnimation;
            _playerAnimation = playerAnimation;

            Definition = definition;
            Transitions = transitions;
        }

        private readonly IProjectileStarterConfig _projectileConfig;
        private readonly IPlayerAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly IUpdater _updater;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IBowConfig _config;
        private readonly IRotation _rotation;
        private readonly IBowGameObject _bowGameObject;
        private readonly IProjectileStarter _projectileStarter;

        private readonly BowShootAnimation _bowAnimation;
        private readonly PlayerShootAnimation _playerAnimation;

        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }
        public PlayerStateDefinition[] Transitions { get; }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _comboStateMachine.Register(lifetime, Definition, this);
        }
        
        public bool IsTransitionToComboAvailable()
        {
            return true;
        }

        public void EnterCombo()
        {
            _stateMachine.Enter(this);

            _updater.Add(this);
            _bowGameObject.Enable();

            Process().Forget();
        }

        public void Break()
        {
            _updater.Remove(this);
            _bowGameObject.Disable();

            Cancel();
        }

        public void OnUpdate(float delta)
        {
            _playerAnimation.SetOrientation(_rotation.Orientation);
            _spriteFlip.FlipAlong(_rotation.Angle);
        }

        private async UniTask Process()
        {
            Cancel();

            _cancellation = new CancellationTokenSource();

            var shootParams = new ShootParams(
                _config.Damage.Value,
                _config.PushForce.Value,
                _config.ArrowSpeed.Value,
                _projectileConfig.Scale,
                _projectileConfig.Radius);
            
            _projectileStarter.Shoot(_rotation.Angle, _projectileConfig.Data.Definition, shootParams);

            var playerAnimationTask = _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);
            var bowAnimationTask = _bowAnimator.PlayAsync(_bowAnimation, _cancellation.Token);

            await UniTask.WhenAll(tasks: new[] { playerAnimationTask, bowAnimationTask });

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