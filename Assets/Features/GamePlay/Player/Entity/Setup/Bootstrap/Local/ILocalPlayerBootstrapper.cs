using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Setup.Root.Local;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Setup.Bootstrap.Local
{
    public interface ILocalPlayerBootstrapper
    {
        UniTask<IPlayerRoot> Bootstrap(LifetimeScope parent, PlayerAttachHandler entityHandler);
    }
}