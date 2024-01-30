using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;

namespace GamePlay.Player.Entity.Equipment.Abstract.Factory
{
    public interface IEquipmentConfig
    {
        IEquipmentInstanceConfig Local { get; }
        IEquipmentInstanceConfig Remote { get; }
        SlotDefinition Slot { get; }
    }
}