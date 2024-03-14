using GamePlay.Cameras.Abstract;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Local;

namespace GamePlay.Player.Entity.Common.Definition
{
    public interface ILocalPlayerRoot : IPlayerRoot
    {
        IEquipper Equipper { get; }
        IFollowTarget FollowTarget { get; }

        void Respawn();
    }
}