using Common.Architecture.Entities.Common.DefaultCallbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Runtime;

namespace GamePlay.Player.Entity.Common.Definition
{
    public interface IPlayerRoot
    {
        IEntityCallbacks Callbacks { get; }
        IHealth Health { get; }
        IPlayerPosition Position { get; }
        IPlayerTransform Transform { get; }

        UniTask Enable();
        UniTask Disable();
    }
}