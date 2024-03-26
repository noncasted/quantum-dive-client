using Common.DataTypes.Runtime.Reactive;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Local.Runtime
{
    public class LocalLocalStateMachine : ILocalStateMachine
    {
        public LocalLocalStateMachine(IStateMachineSync sync)
        {
            _sync = sync;
        }

        private readonly IStateMachineSync _sync;

        private IEnemyLocalState _current;
        private readonly ViewableDelegate<EnemyStateDefinition> _entered = new();
        private readonly ViewableDelegate<EnemyStateDefinition> _exited = new();
        public IViewableDelegate<EnemyStateDefinition> Entered => _entered;
        public IViewableDelegate<EnemyStateDefinition> Exited => _exited;

        public bool IsAvailable(EnemyStateDefinition definition)
        {
            if (_current == null)
                return true;

            var result = _current.Definition.IsTransitable(definition);

            return result;
        }

        public void Enter(IEnemyLocalState enemyLocalState)
        {
            _current.Break();

            _current = enemyLocalState;
            _sync.SetState(enemyLocalState.Definition);

            _entered?.Invoke(_current.Definition);
        }

        public void Enter(IEnemyLocalState enemyLocalState, IRemoteStatePayload payload)
        {
            _current.Break();

            _current = enemyLocalState;
            _sync.SetState(enemyLocalState.Definition, payload);
        }

        public void Exit(IEnemyLocalState playerLocalState)
        {
            if (playerLocalState != _current)
            {
                return;
            }

            _current.Break();
            _exited?.Invoke(_current.Definition);
            _current = null;
        }
    }
}