using GamePlay.Enemy.Entity.States.Abstract;

namespace GamePlay.Enemy.Services.Mappers.States.Abstract
{
    public interface IEnemyStateMapper
    {
        int GetId(EnemyStateDefinition definition);
        EnemyStateDefinition GetDefinition(int id);
    }
}