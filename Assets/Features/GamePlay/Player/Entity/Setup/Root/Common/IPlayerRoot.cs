using Common.Architecture.Entities.Common.DefaultCallbacks;
using Cysharp.Threading.Tasks;

namespace GamePlay.Player.Entity.Setup.Root.Common
{
    public interface IPlayerRoot
    {
        IEntityCallbacks Callbacks { get; }
        UniTask Enable();
        UniTask Disable();
    }
}