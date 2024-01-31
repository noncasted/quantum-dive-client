using System;
using GamePlay.Player.Entity.Components.StateMachines.Local.Logs;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Runtime
{
    public class LocalStateMachine : ILocalStateMachine
    {
        public LocalStateMachine(IStateMachineSync sync, LocalStateMachineLogger logger)
        {
            _sync = sync;
            _logger = logger;
        }

        private readonly IStateMachineSync _sync;
        private readonly LocalStateMachineLogger _logger;

        private IPlayerLocalState _current;

        public event Action Exited;

        public bool IsAvailable(PlayerStateDefinition definition)
        {
            if (_current == null)
                return true;

            var result = _current.Definition.IsTransitable(definition);

            _logger.OnAvailabilityChecked(_current.Definition, definition, result);

            return result;
        }

        public void Enter(IPlayerLocalState playerLocalState)
        {
            if (_current == null)
                _logger.OnEnteredFirst(playerLocalState.Definition);
            else
                _logger.OnEnteredFrom(_current.Definition, playerLocalState.Definition);

            _current?.Break();

            _current = playerLocalState;
            _sync.SetState(playerLocalState.Definition);
        }

        public void Enter(IPlayerLocalState playerLocalState, IPlayerRemoteStatePayload payload)
        {
            if (_current == null)
                _logger.OnEnteredFirst(playerLocalState.Definition);
            else
                _logger.OnEnteredFrom(_current.Definition, playerLocalState.Definition);

            _current?.Break();

            _current = playerLocalState;
            _sync.SetState(playerLocalState.Definition);
        }

        public void Exit(IPlayerLocalState playerLocalState)
        {
            if (playerLocalState != _current)
            {
                _logger.OnExitMiss(playerLocalState.Definition);
                return;
            }
            
            _logger.OnExited(_current.Definition);
            Exited?.Invoke();
        }
    }
}