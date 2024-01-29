using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Equipment.Equipper.Local;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;

namespace GamePlay.Player.Entity.Setup.Root.Local
{
    public interface IPlayerRoot
    {
        IHealth Health { get; }
        IPlayerPosition Position { get; }
        IPlayerTransformProvider Transform { get; }
        IEquipper Equipper { get; }

        UniTask OnBootstrapped();

        void Respawn();
        void Enable();
        void Disable();
    }
}