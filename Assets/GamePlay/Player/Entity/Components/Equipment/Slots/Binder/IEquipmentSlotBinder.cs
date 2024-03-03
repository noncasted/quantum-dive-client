using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Binder
{
    public interface IEquipmentSlotBinder
    {
        void Bind(SlotDefinition definition, Transform equipment);
    }
}