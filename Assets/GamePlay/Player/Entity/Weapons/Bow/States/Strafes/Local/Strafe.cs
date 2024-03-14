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
using GamePlay.Player.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Player.Entity.Views.Animators.Abstract;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Local
{
    public class Strafe :
        IPlayerLocalState,
        IStrafe
    {
        public Strafe(
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            IUpdater updater,
            IPlayerAnimator playerAnimator,
            IRotation rotation,
            IBowArrow arrow,
            IBowAnimator bowAnimator,
            IBowGameObject bowGameObject,
            IProjectileStarterConfig projectileStarterConfig,
            IStrafeInputReceiver input,
            IAngleSteering steering,
            ISubPush subPush,
            PushParams pushParams,
            IAnimation playerAnimation,
            IAnimation bowAnimation,
            StrafeDefinition definition,
            PlayerStateDefinition[] transitions)
        {
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _updater = updater;

            _playerAnimator = playerAnimator;
            _rotation = rotation;

            _arrow = arrow;
            _bowAnimator = bowAnimator;
            _bowGameObject = bowGameObject;
            _projectileStarterConfig = projectileStarterConfig;

            _input = input;
            _steering = steering;
            _subPush = subPush;

            _pushParams = pushParams;
            _playerAnimation = playerAnimation;
            _bowAnimation = bowAnimation;

            _definition = definition;
            _transitions = transitions;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IUpdater _updater;

        private readonly IEnhancedAnimator _playerAnimator;
        private readonly IRotation _rotation;

        private readonly IBowArrow _arrow;
        private readonly IBowAnimator _bowAnimator;
        private readonly IBowGameObject _bowGameObject;
        private readonly IProjectileStarterConfig _projectileStarterConfig;

        private readonly IStrafeInputReceiver _input;
        private readonly IAngleSteering _steering;
        private readonly ISubPush _subPush;
        private readonly PushParams _pushParams;

        private readonly IAnimation _playerAnimation;
        private readonly IAnimation _bowAnimation;

        private readonly StrafeDefinition _definition;
        private readonly PlayerStateDefinition[] _transitions;

        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition => _definition;

        public void Break()
        {
            _arrow.Hide();

            Cancel();
        }

        public void Enter()
        {
            _stateMachine.Enter(this);
            _cancellation = new CancellationTokenSource();

            _bowGameObject.Enable();
            _arrow.Show(_projectileStarterConfig.Data.Preview);

            Process().Forget();
        }

        private async UniTask Process()
        {
            var playerAnimationTask = _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);
            var pushTask = _subPush.PushAsync(_input.Direction, _pushParams, _cancellation.Token);
            _steering.Start(_playerAnimation.Data.Clip.length  / 2f);
            await UniTask.WhenAll(tasks: new[] { playerAnimationTask, pushTask });
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