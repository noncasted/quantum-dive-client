using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Abstract;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local
{
    public class Transition : IMeleeAttackTransition
    {
        public Transition(
            ITargetChecker targetChecker,
            ITargetProvider targetProvider,
            IMeleeAttack state,
            ILocalStateMachine stateMachine,
            MeleeAttackDefinition definition)
        {
            _targetChecker = targetChecker;
            _targetProvider = targetProvider;
            _state = state;
            _stateMachine = stateMachine;
            _definition = definition;
        }

        private readonly ITargetChecker _targetChecker;
        private readonly ITargetProvider _targetProvider;
        private readonly IMeleeAttack _state;
        private readonly ILocalStateMachine _stateMachine;
        private readonly MeleeAttackDefinition _definition;

        public bool IsAvailable()
        {
            if (_targetProvider.Current == null)
                return false;

            if (_stateMachine.IsAvailable(_definition) == false)
                return false;

            if (_targetChecker.IsAvailable(_targetProvider.Current) == false)
                return false;

            return true;
        }

        public void Transit()
        {
            _state.Attack(_targetProvider.Current).Forget();
        }
    }
}