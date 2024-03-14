using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Common.Definition;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    public interface IPlayerFactory
    {
        UniTask<ILocalPlayerRoot> Create();
    }
}