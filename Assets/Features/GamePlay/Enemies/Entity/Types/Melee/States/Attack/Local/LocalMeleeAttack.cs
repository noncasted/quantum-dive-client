using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Enemies.Entity.Types.Melee.States.Attack.Common;
using GamePlay.Enemies.Entity.Types.Melee.States.Attack.Common.Animation;
using GamePlay.Enemies.Entity.Types.Melee.States.Attack.Common.Config;
using GamePlay.Enemies.Entity.Types.Melee.States.Attack.Damages;
using GamePlay.Enemies.Entity.Types.Melee.States.Attack.Debug;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Entity.Types.Melee.States.Attack.Local
{
    public class LocalMeleeAttack : IEnemyLocalState, IMeleeAttack
    {
        public LocalMeleeAttack(
            ILocalStateMachine stateMachine,
            IMeleeAttackConfig config,
            IMeleeAttackGizmosDrawer gizmosDrawer,
            ISubPush push,

            IEnemyAnimator animator,
            IEnemyPosition position,
            IDamageTrigger damageTrigger,

            MeleeAttackAnimation animation,
            MeleeAttackDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _position = position;
            _damageTrigger = damageTrigger;
            _config = config;
            _gizmosDrawer = gizmosDrawer;
            _push = push;
            _animation = animation;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemyPosition _position;
        private readonly IDamageTrigger _damageTrigger;
        private readonly IMeleeAttackConfig _config;
        private readonly IMeleeAttackGizmosDrawer _gizmosDrawer;
        private readonly ISubPush _push;

        private readonly MeleeAttackAnimation _animation;
        private readonly MeleeAttackDefinition _definition;

        private CancellationTokenSource _cancellation;

        public EnemyStateDefinition Definition => _definition;

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;

            _gizmosDrawer.Disable();
            _damageTrigger.Disable();
        }

        public async UniTask Attack(ISearchableTarget target)
        {
            _stateMachine.Enter(this);

            _cancellation = new CancellationTokenSource();

            _gizmosDrawer.Enable();

            _damageTrigger.Enable();

            var animationTask = _animator.PlayAsync(_animation, _cancellation.Token);

            var pushParams = new PushParams(_config.DashTime, _config.DashDistance, _config.DashCurve);
            var direction = (target.Position - _position.Position).normalized;

            var pushTask = _push.PushAsync(direction, pushParams, _cancellation.Token);

            await UniTask.WhenAll(animationTask, pushTask);

            _stateMachine.Exit(this);
        }
    }
}