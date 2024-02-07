using GamePlay.Enemies.Entity.Definition.Config;

namespace GamePlay.Enemies.Entity.Definition.Asset.Abstract
{
    public interface IEnemyConfiguration
    {
        int StartupInstances { get; }
        ILocalEnemyConfig Local { get; }
        IRemoteEnemyConfig Remote { get; }
    }
}