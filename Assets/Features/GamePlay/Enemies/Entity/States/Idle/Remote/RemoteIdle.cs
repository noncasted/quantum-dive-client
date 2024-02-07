using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.States.Idle.Common;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using Ragon.Protocol;

namespace GamePlay.Enemies.Entity.States.Idle.Remote
{
    public class RemoteIdle : IEnemyRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteIdle(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IdleAnimation animation,
            IdleDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IdleAnimation _animation;
        private readonly IdleDefinition _definition;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }

        public void Enter(RagonBuffer buffer)
        {
            _animator.PlayLooped(_animation);
        }

        public void Break()
        {
        }
    }
}