using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Abstract;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime;
using GamePlay.Enemy.Entity.States.Idle.Common;

namespace GamePlay.Enemy.Entity.States.Idle.Local
{
    public class IdleTransition : IIdleTransition
    {
        public IdleTransition(
            ITargetProvider targetProvider,
            ILocalStateMachine stateMachine,
            IIdle state,
            IdleDefinition definition)
        {
            _targetProvider = targetProvider;
            _stateMachine = stateMachine;
            _state = state;
            _definition = definition;
        }
        
        private readonly ITargetProvider _targetProvider;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IIdle _state;
        
        private readonly IdleDefinition _definition;

        public bool IsAvailable()
        {
            if (_stateMachine.IsAvailable(_definition) == false)
                return false;

            if (_targetProvider.IsTargetReached == false && _targetProvider.Current != null)
                return false;

            return true;
        }

        public void Transit()
        {
            _state.Enter();
        }
    }
}