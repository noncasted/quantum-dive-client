using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Mappers.States.Runtime
{
    public interface IEnemyStateMapper
    {
        int GetId(EnemyStateDefinition definition);
        EnemyStateDefinition GetDefinition(int id);
    }
}