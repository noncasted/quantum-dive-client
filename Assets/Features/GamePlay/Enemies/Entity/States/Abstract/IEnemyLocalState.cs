namespace GamePlay.Enemies.Entity.States.Abstract
{
    public interface IEnemyLocalState
    {
        EnemyStateDefinition Definition { get; }
        
        void Break();
    }
}