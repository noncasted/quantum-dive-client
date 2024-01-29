using GamePlay.Player.Entity.Equipment.Abstract.Definition;

namespace GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime
{
    public interface IEquipmentSlotsStorage
    {
        void Equip(IEquipment equipment);
    }
}