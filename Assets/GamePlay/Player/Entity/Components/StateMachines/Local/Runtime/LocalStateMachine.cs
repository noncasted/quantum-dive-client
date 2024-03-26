using Common.DataTypes.Runtime.Reactive;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using Internal.Scopes.Abstract.Instances.Entities;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Runtime
{
    public class LocalStateMachine : ILocalStateMachine, IEntityDisableListener
    {
        public LocalStateMachine(IStateMachineSync sync)
        {
            _sync = sync;
        }

        private readonly IStateMachineSync _sync;
        private readonly ViewableDelegate _exited = new();

        private IPlayerLocalState _current;

        public IViewableDelegate Exited => _exited;

        public bool IsAvailable(PlayerStateDefinition definition)
        {
            if (_current == null)
                return true;

            var result = _current.Definition.IsTransitable(definition);

            return result;
        }

        public void Enter(IPlayerLocalState playerLocalState)
        {
            _current?.Break();

            _current = playerLocalState;
            _sync.SetState(playerLocalState.Definition);
        }

        public void Enter(IPlayerLocalState playerLocalState, IPlayerRemoteStatePayload payload)
        {
            _current?.Break();

            _current = playerLocalState;
            _sync.SetState(playerLocalState.Definition);
        }

        public void Exit(IPlayerLocalState playerLocalState)
        {
            if (playerLocalState != _current)
            {
                return;
            }

            _exited?.Invoke();
        }

        public void OnDisabled()
        {
            _current?.Break();
        }
    }
}