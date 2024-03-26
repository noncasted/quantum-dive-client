using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Idle.Common;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.States.Idle.Remote
{
    public class RemoteIdle : IEnemyRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteIdle(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IdleDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IdleDefinition _definition;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }

        public void Enter(RagonBuffer buffer)
        {
        }

        public void Break()
        {
        }
    }
}