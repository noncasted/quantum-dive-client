using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Starter;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Weapons.Combo.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Local
{
    public class StanceShoot : IPlayerLocalState, IUpdatable, IComboState, IPlayerSwitchListener
    {
        public StanceShoot(
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            
            IProjectileStarter projectileStarter,
            IProjectileStarterConfig config,
            
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
            _config = config;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _spriteFlip = spriteFlip;
            _updater = updater;
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _rotation = rotation;
            _bowGameObject = bowGameObject;
            _projectileStarter = projectileStarter;
            _bowAnimation = bowAnimation;
            _playerAnimation = playerAnimation;

            Definition = definition;
            Transitions = transitions;
        }

        private readonly IProjectileStarterConfig _config;
        private readonly IPlayerAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly IUpdater _updater;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IRotation _rotation;
        private readonly IBowGameObject _bowGameObject;
        private readonly IProjectileStarter _projectileStarter;

        private readonly BowShootAnimation _bowAnimation;
        private readonly PlayerShootAnimation _playerAnimation;

        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }
        public PlayerStateDefinition[] Transitions { get; }

        public void OnEnabled()
        {
            _comboStateMachine.Register(Definition, this);
        }

        public void OnDisabled()
        {
            _comboStateMachine.Unregister(Definition);
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

            _projectileStarter.Shoot(_rotation.Angle, _config.Data.Definition, _config.Params);

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