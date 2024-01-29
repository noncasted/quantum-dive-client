using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Setup.Root.Remote;
using Ragon.Client;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Setup.Bootstrap.Remote
{
    public interface IRemotePlayerBootstrapper
    {
        UniTask<IRemotePlayerRoot> Bootstrap(LifetimeScope parent, RagonEntity entity);
    }
}