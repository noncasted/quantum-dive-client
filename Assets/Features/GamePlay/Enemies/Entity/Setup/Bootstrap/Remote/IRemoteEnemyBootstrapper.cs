using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Setup.Root.Remote;
using VContainer.Unity;

namespace GamePlay.Enemies.Entity.Setup.Bootstrap.Remote
{
    public interface IRemoteEnemyBootstrapper
    {
        UniTask<IRemoteEnemyRoot> Bootstrap(LifetimeScope parent);
    }
}