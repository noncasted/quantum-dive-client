using GamePlay.Player.Entity.Components.Equipment.Equipper.Local;
using GamePlay.Services.Cameras.Abstract;

namespace GamePlay.Player.Entity.Common.Definition
{
    public interface ILocalPlayerRoot : IPlayerRoot
    {
        IEquipper Equipper { get; }
        IFollowTarget FollowTarget { get; }

        void Respawn();
    }
}