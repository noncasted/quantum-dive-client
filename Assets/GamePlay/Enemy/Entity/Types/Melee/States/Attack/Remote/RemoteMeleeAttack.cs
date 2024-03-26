using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Damages;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Remote
{
    public class RemoteMeleeAttack : IEnemyRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteMeleeAttack(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IDamageTrigger damageTrigger,
            MeleeAttackDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _damageTrigger = damageTrigger;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IDamageTrigger _damageTrigger;
        private readonly MeleeAttackDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }

        public void Enter(RagonBuffer buffer)
        {
            _damageTrigger.Enable();
            _cancellation = new CancellationTokenSource();
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