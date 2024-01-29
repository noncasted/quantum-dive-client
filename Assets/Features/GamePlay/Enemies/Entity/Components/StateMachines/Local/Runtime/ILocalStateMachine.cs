using System;
using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime
{
    public interface ILocalStateMachine
    {
        event Action<EnemyStateDefinition> Entered;
        event Action<EnemyStateDefinition> Exited;

        bool IsAvailable(EnemyStateDefinition definition);
        void Enter(IEnemyLocalState enemyLocalState);
        void Enter(IEnemyLocalState enemyLocalState, IRemoteStatePayload payload);
        void Exit(IEnemyLocalState enemyLocalState);
    }
}