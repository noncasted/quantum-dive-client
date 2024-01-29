using GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.States.Idle.Common;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;

namespace GamePlay.Enemies.Entity.States.Idle.Local
{
    public class LocalIdle : IIdle, IEnemyLocalState
    {
        public LocalIdle(
            ILocalStateMachine stateMachine,
            IEnemyAnimator animator,
            IdleAnimation animation,
            IdleDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IdleAnimation _animation;
        private readonly IdleDefinition _definition;

        public EnemyStateDefinition Definition => _definition;
        
        public void Enter()
        {
            _stateMachine.Enter(this);
            
            _animator.PlayLooped(_animation);
        }
        
        public void Break()
        {
            
        }
    }
}