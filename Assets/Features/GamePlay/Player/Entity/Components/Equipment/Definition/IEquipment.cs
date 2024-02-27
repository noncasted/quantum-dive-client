using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Definition
{
    public interface IEquipment
    {
        SlotDefinition Slot { get; }
        Transform Transform { get; }
        void Select();
        void Deselect();
    }
}