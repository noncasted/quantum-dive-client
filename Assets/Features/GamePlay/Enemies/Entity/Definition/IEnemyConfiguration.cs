using Features.GamePlay.Enemies.Entity.Setup.Configs;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    public interface IEnemyConfiguration
    {
        int StartupInstances { get; }
        ILocalEnemyConfig Local { get; }
        IRemoteEnemyConfig Remote { get; }
    }
}