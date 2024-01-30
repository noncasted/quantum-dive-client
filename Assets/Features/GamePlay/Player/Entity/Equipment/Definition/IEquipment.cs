using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Abstract.Definition
{
    public interface IEquipment
    {
        SlotDefinition Slot { get; }
        Transform Transform { get; }
        void Select();
        void Deselect();
    }
}