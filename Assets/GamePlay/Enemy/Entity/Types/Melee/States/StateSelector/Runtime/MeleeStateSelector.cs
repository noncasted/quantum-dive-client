using GamePlay.Enemy.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemy.Entity.Components.StateSelectors;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Following.Local;
using GamePlay.Enemy.Entity.States.Idle.Local;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local;
using GamePlay.Enemy.Updater.Runtime;
using GamePlay.Enemy.Updater.Runtime.Updatables;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Enemy.Entity.Types.Melee.States.StateSelector.Runtime
{
    public class MeleeStateSelector :
        IStateSelector,
        IEntitySwitchLifetimeListener,
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
        private EnemyStateDefinition _current;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.Entered.Listen(lifetime, OnStateEntered);
            _stateMachine.Exited.Listen(lifetime, OnStateExited);

            _updater.Add(lifetime, this);
        }

        public void Start()
        {
            OnStateSelect();
        }

        public void OnStateSelect()
        {
            if (_isStateEntered == true)
                return;

            if (_current == null || _current.IsBackground == true)
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
            _current = definition;
            _isStateEntered = false;
        }

        private void OnStateEntered(EnemyStateDefinition definition)
        {
            _isStateEntered = true;
        }
    }
}