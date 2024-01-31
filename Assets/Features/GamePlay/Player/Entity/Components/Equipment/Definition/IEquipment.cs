using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace Features.GamePlay.Player.Entity.Components.Equipment.Definition
{
    public interface IEquipment
    {
        SlotDefinition Slot { get; }
        Transform Transform { get; }
        void Select();
        void Deselect();
    }
}