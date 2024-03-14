using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Healths.Abstract;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using Internal.Scopes.Common.Entity;

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