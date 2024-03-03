using Common.Architecture.Lifetimes;
using GamePlay.Enemy.Entity.States.Abstract;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Remote.Runtime
{
    public interface IRemoteStateMachine
    {
        void RegisterState(ILifetime lifetime, EnemyStateDefinition definition, IEnemyRemoteState state);

        void RegisterFlush(ILifetime lifetime, EnemyStateDefinition definition, IRemoteStatePayloadFlush flush);
    }
}