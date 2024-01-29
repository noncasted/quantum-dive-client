using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Types.Melee.States.Attack.Common;
using GamePlay.Enemies.Types.Melee.States.Attack.Common.Animation;
using GamePlay.Enemies.Types.Melee.States.Attack.Damages;
using Ragon.Protocol;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Remote
{
    public class RemoteMeleeAttack : IEnemyRemoteState, IEnemySwitchListener
    {
        public RemoteMeleeAttack(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IDamageTrigger damageTrigger,
            MeleeAttackAnimation animation,
            MeleeAttackDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _damageTrigger = damageTrigger;
            _animation = animation;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IDamageTrigger _damageTrigger;
        private readonly MeleeAttackAnimation _animation;
        private readonly MeleeAttackDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnEnabled()
        {
            _stateMachine.RegisterState(_definition, this);
        }

        public void OnDisabled()
        {
            _stateMachine.UnregisterState(_definition);
        }

        public void Enter(RagonBuffer buffer)
        {
            _damageTrigger.Enable();
            _cancellation = new CancellationTokenSource();
            _animator.PlayAsync(_animation, _cancellation.Token).Forget();
        }

        public void Break()
        {
            _damageTrigger.Disable();
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}