using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Abstract;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime;
using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    public class ShootTransition : IShootTransition
    {
        public ShootTransition(
            ITargetProvider targetProvider,
            ILocalStateMachine stateMachine,
            IShoot state,
            IShootTargetChecker targetChecker,
            ShootDefinition definition)
        {
            _targetProvider = targetProvider;
            _stateMachine = stateMachine;
            _state = state;
            _targetChecker = targetChecker;
            _definition = definition;
        }
        
        private readonly ITargetProvider _targetProvider;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IShoot _state;
        private readonly IShootTargetChecker _targetChecker;

        private readonly ShootDefinition _definition;
        
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
            _targetChecker.OnShoot();
            _state.Shoot(_targetProvider.Current).Forget();
        }
    }
}