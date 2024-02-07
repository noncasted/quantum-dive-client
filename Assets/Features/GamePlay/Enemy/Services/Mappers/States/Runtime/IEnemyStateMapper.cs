using GamePlay.Enemy.Entity.States.Abstract;

namespace GamePlay.Enemy.Mappers.States.Runtime
{
    public interface IEnemyStateMapper
    {
        int GetId(EnemyStateDefinition definition);
        EnemyStateDefinition GetDefinition(int id);
    }
}