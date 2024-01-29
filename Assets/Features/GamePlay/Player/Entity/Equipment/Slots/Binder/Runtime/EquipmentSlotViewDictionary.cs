using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;

namespace GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime
{
    [Serializable]
    public class EquipmentSlotViewDictionary : SerializableDictionary<SlotDefinition, EquipmentSlotView>
    {
        
    }
}