namespace GamePlay.Enemy.Entity.Definition.Asset.Abstract
{
    public interface IEnemyIdentification
    {
        int Id { get; }
        string Name { get; }

        void SetId(int id);
    }
}