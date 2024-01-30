using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Setup.Root.Local;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    public interface IPlayerFactory
    {
        UniTask<ILocalPlayerRoot> Create();
    }
}