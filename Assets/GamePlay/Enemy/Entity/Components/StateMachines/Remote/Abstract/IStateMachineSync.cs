using GamePlay.Enemy.Entity.States.Abstract;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Remote.Abstract
{
    public interface IStateMachineSync
    {
        void SetState(EnemyStateDefinition definition);
        void SetState(EnemyStateDefinition definition, IRemoteStatePayload payload);
    }
}