﻿using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime
{
    public class EquipmentSlotsStorage : IEquipmentSlotsStorage
    {
        private readonly Dictionary<SlotDefinition, IEquipment> _slots = new();

        public void Equip(IEquipment equipment)
        {
            var definition = equipment.Slot;

            if (_slots.ContainsKey(definition) == false)
            {
                _slots.Add(definition, equipment);
                equipment.Select();

                return;
            }
            
            _slots[definition].Deselect();
            _slots[definition] = equipment;
            equipment.Select();
        }
    }
}