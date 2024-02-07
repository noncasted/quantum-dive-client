using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Definition;

namespace GamePlay.Player.Factory.Factory.Runtime
{
    public interface IPlayerFactory
    {
        UniTask<ILocalPlayerRoot> Create();
    }
}