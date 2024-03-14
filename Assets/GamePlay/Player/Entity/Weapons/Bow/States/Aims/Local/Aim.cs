using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Combo.Abstract;
using GamePlay.Player.Entity.Components.Combo.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Local.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Views.Animators.Abstract;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Physics.Abstract;
using GamePlay.Player.Entity.Views.Physics.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local
{
    public class Aim : IPlayerLocalState, IAim
    {
        public Aim(
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            IPlayerAnimator playerAnimator,
            IBowAnimator bowAnimator,
            IBowGameObject bowGameObject,
            IBowArrow arrow,
            IProjectileStarterConfig config,
            IUpdater updater,
            IRotation rotation,
            IAnimation playerAnimation,
            IPlayerPhysics physics,
            IAngleSteering steering,
            //BowAimAnimation bowAnimation,
            AimDefinition definition,
            PlayerStateDefinition[] transitions)
        {
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _bowGameObject = bowGameObject;
            _arrow = arrow;
            _config = config;
            _updater = updater;
            _rotation = rotation;
            _playerAnimation = playerAnimation;
            _physics = physics;
            _steering = steering;
            //_bowAnimation = bowAnimation;
            _transitions = transitions;

            Definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IEnhancedAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IBowGameObject _bowGameObject;
        private readonly IUpdater _updater;
        private readonly IRotation _rotation;
        private readonly IBowArrow _arrow;
        private readonly IProjectileStarterConfig _config;

        private readonly IAnimation _playerAnimation;
        private readonly IPlayerPhysics _physics;
        private readonly IAngleSteering _steering;

        //private readonly BowAimAnimation _bowAnimation;
        private readonly PlayerStateDefinition[] _transitions;

        private bool _isEntered;
        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }
        public bool IsEntered => _isEntered;

        public void Enter()
        {
            _stateMachine.Enter(this);

            _isEntered = true;
            _bowGameObject.Enable();
            _arrow.Show(_config.Data.Preview);

            Process().Forget();
        }

        public void Break()
        {
            _isEntered = false;
            _arrow.Hide();

            Cancel();
        }

        private async UniTask Process()
        {
            _cancellation = new CancellationTokenSource();

            _steering.Start(_playerAnimation.Data.Clip.length / 2f);
            await _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);
            _steering.Stop();
            
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