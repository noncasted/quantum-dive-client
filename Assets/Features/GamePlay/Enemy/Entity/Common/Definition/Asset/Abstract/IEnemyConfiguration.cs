using GamePlay.Enemy.Entity.Common.Definition.Config;

namespace GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract
{
    public interface IEnemyConfiguration
    {
        int StartupInstances { get; }
        ILocalEnemyConfig Local { get; }
        IRemoteEnemyConfig Remote { get; }
    }
}