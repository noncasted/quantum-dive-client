﻿using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Binder
{
    [Serializable]
    public class EquipmentSlotViewDictionary : SerializableDictionary<SlotDefinition, EquipmentSlotView>
    {
        
    }
}