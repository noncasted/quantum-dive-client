using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime
{
    public interface IStateMachineSync
    {
        void SetState(EnemyStateDefinition definition);
        void SetState(EnemyStateDefinition definition, IRemoteStatePayload payload);
    }
}