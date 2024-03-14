using Common.DataTypes.Reactive;
using GamePlay.Enemy.Entity.States.Abstract;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract
{
    public interface ILocalStateMachine
    {
        IViewableDelegate<EnemyStateDefinition>  Entered { get; }
        IViewableDelegate<EnemyStateDefinition>  Exited { get; }

        bool IsAvailable(EnemyStateDefinition definition);
        void Enter(IEnemyLocalState enemyLocalState);
        void Enter(IEnemyLocalState enemyLocalState, IRemoteStatePayload payload);
        void Exit(IEnemyLocalState enemyLocalState);
    }
}