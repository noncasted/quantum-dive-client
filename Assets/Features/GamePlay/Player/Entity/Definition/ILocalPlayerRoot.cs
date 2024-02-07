using GamePlay.Player.Entity.Components.Equipment.Equipper.Local;

namespace GamePlay.Player.Entity.Definition
{
    public interface ILocalPlayerRoot : IPlayerRoot
    {
        IEquipper Equipper { get; }

        void Respawn();
    }
}