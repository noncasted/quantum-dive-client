using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Combo.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local
{
    public class Aim : IPlayerLocalState, IAim, IUpdatable
    {
        public Aim(
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,

            IPlayerAnimator playerAnimator,
            IPlayerSpriteFlip spriteFlip,
            
            IBowAnimator bowAnimator,
            IBowGameObject bowGameObject,            
            IBowArrow arrow,
            IProjectileStarterConfig config,

            IUpdater updater,
            IRotation rotation,

            PlayerAimAnimation playerAnimation,
            BowAimAnimation bowAnimation,
            
            AimDefinition definition,
            PlayerStateDefinition[] transitions)
        {
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _bowGameObject = bowGameObject;
            _spriteFlip = spriteFlip;
            _arrow = arrow;
            _config = config;
            _updater = updater;
            _rotation = rotation;
            _playerAnimation = playerAnimation;
            _bowAnimation = bowAnimation;
            _transitions = transitions;

            Definition = definition;
        }
        
        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IPlayerAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IBowGameObject _bowGameObject;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly IUpdater _updater;
        private readonly IRotation _rotation;
        private readonly IBowArrow _arrow;
        private readonly IProjectileStarterConfig _config;

        private readonly PlayerAimAnimation _playerAnimation;
        private readonly BowAimAnimation _bowAnimation;
        private readonly PlayerStateDefinition[] _transitions;

        private bool _isEntered;
        private CancellationTokenSource _cancellation;
        
        public PlayerStateDefinition Definition { get; }
        public bool IsEntered => _isEntered;

        public void Enter()
        {
            _stateMachine.Enter(this);

            _isEntered = true;
            _updater.Add(this);
            _bowGameObject.Enable();
            _arrow.Show(_config.Data.Preview);

            Process().Forget();
        }

        public void Break()
        {
            _isEntered = false;
            _updater.Remove(this);
            _bowGameObject.Disable();
            _arrow.Hide();

            Cancel();
        }

        public void OnUpdate(float delta)
        {
            _spriteFlip.FlipAlong(_rotation.Angle);
            _playerAnimation.SetOrientation(_rotation.Orientation);
        }
        
        private async UniTask Process()
        {
            _cancellation = new CancellationTokenSource();
            
            var playerAnimationTask = _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);
            var bowAnimationTask = _bowAnimator.PlayAsync(_bowAnimation, _cancellation.Token);
            
            await UniTask.WhenAll(tasks: new[] { playerAnimationTask, bowAnimationTask });

            _comboStateMachine.TryTransitCombo(this, _transitions);
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}