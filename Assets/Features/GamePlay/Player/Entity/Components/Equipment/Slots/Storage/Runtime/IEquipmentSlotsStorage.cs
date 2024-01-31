using Features.GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime
{
    public interface IEquipmentSlotsStorage
    {
        void Equip(IEquipment equipment);
    }
}