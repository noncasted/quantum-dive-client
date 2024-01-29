using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;

namespace GamePlay.Player.Entity.Equipment.Abstract.Definition
{
    public interface IEquipment
    {
        SlotDefinition Slot { get; }
        
        void Select();
        void Deselect();
    }
}