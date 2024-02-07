namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    public interface IEnemyIdentification
    {
        int Id { get; }
        string Name { get; }

        void SetId(int id);
    }
}