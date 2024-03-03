using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Following.Common;
using GamePlay.Enemy.Entity.Views.Animators.Runtime;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.States.Following.Remote
{
    public class RemoteFollowing : IEnemyRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteFollowing(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            FollowingAnimation animation,
            FollowingDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        
        private readonly FollowingAnimation _animation;
        private readonly FollowingDefinition _definition;

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