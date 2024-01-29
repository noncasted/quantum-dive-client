using System;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Logs;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime
{
    public class LocalLocalStateMachine : ILocalStateMachine
    {
        public LocalLocalStateMachine(IStateMachineSync sync, LocalStateMachineLogger logger)
        {
            _sync = sync;
            _logger = logger;
        }

        private readonly IStateMachineSync _sync;
        private readonly LocalStateMachineLogger _logger;

        private IEnemyLocalState _current;

        public event Action<EnemyStateDefinition> Entered;
        public event Action<EnemyStateDefinition> Exited;

        public bool IsAvailable(EnemyStateDefinition definition)
        {
            if (_current == null)
                return true;

            var result = _current.Definition.IsTransitable(definition);

            _logger.OnAvailabilityChecked(_current.Definition, definition, result);

            return result;
        }

        public void Enter(IEnemyLocalState enemyLocalState)
        {
            if (_current == null)
                _logger.OnEnteredFirst(enemyLocalState.Definition);
            else
                _logger.OnEnteredFrom(_current.Definition, enemyLocalState.Definition);

            _current?.Break();

            _current = enemyLocalState;
            _sync.SetState(enemyLocalState.Definition);
            
            Entered?.Invoke(_current.Definition);
        }

        public void Enter(IEnemyLocalState enemyLocalState, IRemoteStatePayload payload)
        {
            if (_current == null)
                _logger.OnEnteredFirst(enemyLocalState.Definition);
            else
                _logger.OnEnteredFrom(_current.Definition, enemyLocalState.Definition);

            _current?.Break();

            _current = enemyLocalState;
            _sync.SetState(enemyLocalState.Definition, payload);
        }

        public void Exit(IEnemyLocalState playerLocalState)
        {
            if (playerLocalState != _current)
            {
                _logger.OnExitMiss(playerLocalState.Definition);
                return;
            }
            
            _logger.OnExited(_current.Definition);
            _current.Break();
            Exited?.Invoke(_current.Definition);
            _current = null;
        }
    }
}