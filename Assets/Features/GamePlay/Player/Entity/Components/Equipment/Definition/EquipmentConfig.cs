using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Definition
{
    public abstract class EquipmentConfig : ScriptableObject, IEquipmentConfig
    {
        public abstract IEquipmentInstanceConfig Local { get; }
        public abstract IEquipmentInstanceConfig Remote { get; }
        public abstract SlotDefinition Slot { get; }
    }
}