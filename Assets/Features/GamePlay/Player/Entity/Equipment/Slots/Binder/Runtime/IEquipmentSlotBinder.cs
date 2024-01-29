using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime
{
    public interface IEquipmentSlotBinder
    {
        void Bind(SlotDefinition definition, Transform equipment);
    }
}