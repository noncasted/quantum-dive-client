using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Common.Definition;

namespace GamePlay.Player.Services.Factory.Factory.Abstract
{
    public interface IPlayerFactory
    {
        UniTask<ILocalPlayerRoot> Create();
    }
}