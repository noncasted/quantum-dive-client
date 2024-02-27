using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;

namespace GamePlay.Player.Entity.Components.Equipment.Definition
{
    public interface IEquipmentConfig
    {
        IEquipmentInstanceConfig Local { get; }
        IEquipmentInstanceConfig Remote { get; }
        SlotDefinition Slot { get; }
    }
}