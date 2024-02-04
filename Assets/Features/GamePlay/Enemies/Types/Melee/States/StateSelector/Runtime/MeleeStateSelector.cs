using GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemies.Entity.Components.StateSelectors;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.States.Following.Local;
using GamePlay.Enemies.Entity.States.Idle.Local;
using GamePlay.Enemies.Services.Updater.Runtime;
using GamePlay.Enemies.Services.Updater.Runtime.Updatables;
using GamePlay.Enemies.Types.Melee.States.Attack.Local;

namespace GamePlay.Enemies.Types.Melee.States.StateSelector.Runtime
{
    public class MeleeStateSelector :
        IStateSelector,
        IEntitySwitchListener,
        IEnemyStateSelectionUpdatable
    {
        public MeleeStateSelector(
            ILocalStateMachine stateMachine,
            IEnemyUpdater updater,

            IIdleTransition idleTransition,
            IFollowingTransition followingTransition,
            IMeleeAttackTransition meleeAttackTransition)
        {
            _stateMachine = stateMachine;
            _updater = updater;
            _transitions = new IStateTransition[]
            {
                idleTransition,
                followingTransition,
                meleeAttackTransition,
            };
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyUpdater _updater;

        private readonly IStateTransition[] _transitions;

        private bool _isStateEntered;

        public void OnEnabled()
        {
            _stateMachine.Entered += OnStateEntered;
            _stateMachine.Exited += OnStateExited;
        }

        public void OnDisabled()
        {
            _stateMachine.Entered -= OnStateEntered;
            _stateMachine.Exited -= OnStateExited;
        }

        public void Start()
        {
            _updater.Add(this);

            OnStateSelect();
        }

        public void OnStateSelect()
        {
            if (_isStateEntered == true)
                return;

            foreach (var transition in _transitions)
            {
                if (transition.IsAvailable() == false)
                    continue;

                transition.Transit();
                break;
            }
        }

        private void OnStateExited(EnemyStateDefinition definition)
        {
            if (definition.IsBackground == false)
                _updater.Add(this);

            _isStateEntered = false;
        }

        private void OnStateEntered(EnemyStateDefinition definition)
        {
            if (definition.IsBackground == false)
                _updater.Remove(this);

            _isStateEntered = true;
        }
    }
}