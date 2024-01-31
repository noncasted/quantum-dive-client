using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Binder.Runtime
{
    public interface IEquipmentSlotBinder
    {
        void Bind(SlotDefinition definition, Transform equipment);
    }
}