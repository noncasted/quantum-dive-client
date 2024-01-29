using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Setup.Root.Local;
using VContainer.Unity;

namespace GamePlay.Enemies.Entity.Setup.Bootstrap.Local
{
    public interface ILocalEnemyBootstrapper
    {
        UniTask<ILocalEnemyRoot> Bootstrap(LifetimeScope parent);
    }
}