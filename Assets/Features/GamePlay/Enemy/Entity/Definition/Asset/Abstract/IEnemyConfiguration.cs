using GamePlay.Enemy.Entity.Definition.Config;

namespace GamePlay.Enemy.Entity.Definition.Asset.Abstract
{
    public interface IEnemyConfiguration
    {
        int StartupInstances { get; }
        ILocalEnemyConfig Local { get; }
        IRemoteEnemyConfig Remote { get; }
    }
}