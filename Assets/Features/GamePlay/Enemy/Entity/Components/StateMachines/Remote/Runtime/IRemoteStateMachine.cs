using Common.Architecture.Lifetimes;
using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime
{
    public interface IRemoteStateMachine
    {
        void RegisterState(ILifetime lifetime, EnemyStateDefinition definition, IEnemyRemoteState state);

        void RegisterFlush(ILifetime lifetime, EnemyStateDefinition definition, IRemoteStatePayloadFlush flush);
    }
}