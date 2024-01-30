using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Abstract.Factory
{
    public abstract class EquipmentConfig : ScriptableObject, IEquipmentConfig
    {
        public abstract IEquipmentInstanceConfig Local { get; }
        public abstract IEquipmentInstanceConfig Remote { get; }
        public abstract SlotDefinition Slot { get; }
    }
}