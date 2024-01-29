using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime
{
    public interface IRemoteStateMachine
    {
        void RegisterState(EnemyStateDefinition definition, IEnemyRemoteState state);
        void UnregisterState(EnemyStateDefinition definition);

        void RegisterFlush(EnemyStateDefinition definition, IRemoteStatePayloadFlush flush);
        void UnregisterFlush(EnemyStateDefinition definition);
    }
}