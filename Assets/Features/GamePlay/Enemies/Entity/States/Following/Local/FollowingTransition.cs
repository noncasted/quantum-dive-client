using GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime;
using GamePlay.Enemies.Entity.States.Following.Common;

namespace GamePlay.Enemies.Entity.States.Following.Local
{
    public class FollowingTransition : IFollowingTransition
    {
        public FollowingTransition(
            ITargetProvider targetProvider,
            ILocalStateMachine stateMachine,
            IFollowing state,
            FollowingDefinition definition)
        {
            _targetProvider = targetProvider;
            _stateMachine = stateMachine;
            _state = state;
            _definition = definition;
        }
        
        private readonly ITargetProvider _targetProvider;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IFollowing _state;
        
        private readonly FollowingDefinition _definition;
        
        public bool IsAvailable()
        {
            if (_targetProvider.Current == null)
                return false;

            if (_stateMachine.IsAvailable(_definition) == false)
                return false;

            if (_targetProvider.IsTargetReached == true)
                return false;
            
            return true;
        }

        public void Transit()
        {
            _state.Follow(_targetProvider.Current);
        }
    }
}