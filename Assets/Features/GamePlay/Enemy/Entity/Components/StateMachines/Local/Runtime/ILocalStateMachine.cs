using System;
using Common.Architecture.Lifetimes.Viewables;
using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime
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