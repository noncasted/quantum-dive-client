using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime
{
    public class EquipmentSlotsStorage : IEquipmentSlotsStorage
    {
        private readonly Dictionary<SlotDefinition, IEquipment> _slots = new();

        public async UniTask Equip(IEquipment equipment)
        {
            var definition = equipment.Slot;

            if (_slots.ContainsKey(definition) == false)
            {
                _slots.Add(definition, equipment);
                await equipment.Select();

                return;
            }

            await _slots[definition].Deselect();
            _slots[definition] = equipment;
            await equipment.Select();
        }
    }
}