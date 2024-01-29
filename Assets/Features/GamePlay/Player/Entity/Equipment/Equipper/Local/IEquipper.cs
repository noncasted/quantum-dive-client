using GamePlay.Player.Entity.Equipment.Abstract.Factory;

namespace GamePlay.Player.Entity.Equipment.Equipper.Local
{
    public interface IEquipper
    {
        void Equip(IEquipmentFactory factory);
    }
}