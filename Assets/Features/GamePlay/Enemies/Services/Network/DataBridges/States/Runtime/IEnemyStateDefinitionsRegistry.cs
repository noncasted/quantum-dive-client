using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Services.Network.DataBridges.States.Runtime
{
    public interface IEnemyStateDefinitionsRegistry
    {
        int GetId(EnemyStateDefinition definition);
        EnemyStateDefinition GetDefinition(int id);
    }
}