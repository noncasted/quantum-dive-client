using Cysharp.Threading.Tasks;

namespace GamePlay.Player.Entity.Setup.Root.Remote
{
    public interface IRemotePlayerRoot
    {
        UniTask OnBootstrapped();
        void OnEntityAttached();
    }
}