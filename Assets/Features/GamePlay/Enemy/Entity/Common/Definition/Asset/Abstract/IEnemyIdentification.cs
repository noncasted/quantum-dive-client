namespace GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract
{
    public interface IEnemyIdentification
    {
        int Id { get; }
        string Name { get; }

        void SetId(int id);
    }
}