﻿using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.Components.StateSelectors;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Following.Local;
using GamePlay.Enemy.Entity.States.Idle.Local;
using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local;
using GamePlay.Enemy.Services.Updater.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Enemy.Entity.Types.Range.States.StateSelector.Runtime
{
    public class RangeStateSelector :
        IStateSelector,
        IEntitySwitchLifetimeListener,
        IEnemyStateSelectionUpdatable
    {
        public RangeStateSelector(
            ILocalStateMachine stateMachine,
            IEnemyUpdater updater,
            IIdleTransition idleTransition,
            IFollowingTransition followingTransition,
            IShootTransition shootTransition)
        {
            _stateMachine = stateMachine;
            _updater = updater;
            _transitions = new IStateTransition[]
            {
                idleTransition,
                followingTransition,
                shootTransition
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