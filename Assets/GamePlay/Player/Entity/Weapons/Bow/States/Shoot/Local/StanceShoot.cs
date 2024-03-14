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
using GamePlay.Player.Entity.Weapons.Bow.Components.Configuration;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using GamePlay.Projectiles.Factory;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Local
{
    public class StanceShoot : IPlayerLocalState, IComboState, IEntitySwitchLifetimeListener
    {
        public StanceShoot(
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            IBowConfig config,
            IProjectileStarter projectileStarter,
            IProjectileStarterConfig projectileConfig,
            
            IAnimation playerAnimation,
            IPlayerAnimator playerAnimator,
            IRotation rotation,
            
            IBowAnimator bowAnimator,
            IBowGameObject bowGameObject,

            IUpdater updater,
            PlayerStateDefinition[] transitions,
            BowShootDefinition definition)
        {
            _projectileConfig = projectileConfig;
            _playerAnimation = playerAnimation;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _updater = updater;
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _config = config;
            _rotation = rotation;
            _bowGameObject = bowGameObject;
            _projectileStarter = projectileStarter;

            Definition = definition;
            Transitions = transitions;
        }

        private readonly IProjectileStarterConfig _projectileConfig;
        private readonly IAnimation _playerAnimation;
        private readonly IEnhancedAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IUpdater _updater;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IBowConfig _config;
        private readonly IRotation _rotation;
        private readonly IBowGameObject _bowGameObject;
        private readonly IProjectileStarter _projectileStarter;

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

            Cancel();

            Process().Forget();
        }

        private async UniTask Process()
        {
            _cancellation = new CancellationTokenSource();

            var shootParams = new ShootParams(
                _config.Damage.Value,
                _config.PushForce.Value,
                _config.ArrowSpeed.Value,
                _projectileConfig.Scale,
                _projectileConfig.Radius); 

            _projectileStarter.Shoot(_rotation.Angle, _projectileConfig.Data.Definition, shootParams);
            _comboStateMachine.TryTransitCombo(this, Transitions);
        }

        public void Break()
        {
            Cancel();
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}