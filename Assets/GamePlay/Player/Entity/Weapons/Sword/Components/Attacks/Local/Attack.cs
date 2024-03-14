using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Components.Rotations.Local.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Abstract;
using GamePlay.Player.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common;
using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Local
{
    public class Attack :
        IPlayerLocalState,
        IFloatingTransition,
        IEntitySwitchLifetimeListener,
        IUpdatable
    {
        public Attack(
            IInputReceiver inputReceiver,
            ITargetsSearcher targetsSearcher,
            IEnhancedAnimator animator,
            IUpdater updater,
            IRotation rotation,
            IAttackArea attackArea,
            ILocalStateMachine stateMachine,
            ISubPush subPush,
            ISwordAttackConfig config,
            IPlayerPosition position,
            PushParams pushParams,
            SwordAttackDefinition definition)
        {
            _inputReceiver = inputReceiver;
            _targetsSearcher = targetsSearcher;
            _animator = animator;
            _updater = updater;
            _rotation = rotation;
            _stateMachine = stateMachine;
            _config = config;
            _position = position;
            _pushParams = pushParams;

            

            Definition = definition;
        }

        private readonly IInputReceiver _inputReceiver;
        private readonly ITargetsSearcher _targetsSearcher;
        private readonly IEnhancedAnimator _animator;
        private readonly IUpdater _updater;
        private readonly IRotation _rotation;
        private readonly IAttackArea _attackArea;
        private readonly ILocalStateMachine _stateMachine;
        private readonly ISwordAttackConfig _config;
        private readonly IPlayerPosition _position;
        private readonly PushParams _pushParams;

        private bool _isEntered;
        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
            lifetime.ListenTerminate(OnLifetimeTerminated);
        }

        public void Break()
        {
            _isEntered = false;
            Cancel();
        }

        public bool IsTransitionFromFloatingAvailable()
        {
            if (_inputReceiver.IsPerformed == false)
                return false;

            if (_isEntered == true)
                return false;

            return true;
        }

        public void EnterFromFloating()
        {
            Process().Forget();
        }

        public void OnUpdate(float delta)
        {
            if (IsTransitionFromFloatingAvailable() == true && _stateMachine.IsAvailable(Definition))
                Process().Forget();

            if (_isEntered == false)
                return;
        }

        private async UniTask Process()
        {
            _stateMachine.Enter(this);
            _cancellation = new CancellationTokenSource();
            _isEntered = true;
            
            //
            // var animationTask = _animator.PlayAsync(_animation, _cancellation.Token);
            //
            // await UniTask.WhenAll(animationTask);

            _isEntered = false;
            _stateMachine.Exit(this);
        }

        private void OnAttackFrame()
        {
            var angle = _rotation.Angle;
            var damageReceivers = _attackArea.GetDamageReceivers(angle);

            foreach (var damageReceiver in damageReceivers)
            {
                var direction = (damageReceiver.Position - _position.Position).normalized;
                var damage = new Damage(_config.Damage, _config.PushForce, direction);
                damageReceiver.ReceiveDamage(damage);
            }
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
        
        private void OnLifetimeTerminated()
        {
            if (_isEntered == true)
            {
                _stateMachine.Exit(this);

                Break();
            }

            _isEntered = false;
        }
    }
}