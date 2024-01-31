using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Setup.Root.Local;

namespace GamePlay.Player.Factory.Factory.Runtime
{
    public interface IPlayerFactory
    {
        UniTask<ILocalPlayerRoot> Create();
    }
}