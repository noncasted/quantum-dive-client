using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Combo.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Local.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Views.Animators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Local
{
    public class Reload : IComboState, IPlayerLocalState, IUpdatable, IEntitySwitchLifetimeListener
    {
        public Reload(
            IBowShootInputReceiver inputReceiver,
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            IBowGameObject gameObject,
            IPlayerAnimator playerAnimator,
            IBowAnimator bowAnimator,
            IRotation rotation,
            IBowArrow arrow,
            IProjectileStarterConfig config,

            IAnimation bowAnimation,
            IAnimation playerAnimation,
            IAngleSteering steering,
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
            _steering = steering;
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
        private readonly IAnimation _bowAnimation;
        private readonly IAnimation _playerAnimation;
        private readonly IAngleSteering _steering;

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
            Cancel();
        }

        public void OnUpdate(float delta)
        {
        }

        private async UniTask Process()
        {
            _cancellation = new CancellationTokenSource();

            _steering.Start(_playerAnimation.Data.Clip.length  / 2f);
            await _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);
            _steering.Stop();

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