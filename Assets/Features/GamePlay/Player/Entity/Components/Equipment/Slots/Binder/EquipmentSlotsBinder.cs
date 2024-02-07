using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Binder
{
    [DisallowMultipleComponent]
    public class EquipmentSlotsBinder : MonoBehaviour, IEquipmentSlotBinder
    {
        [SerializeField] private EquipmentSlotViewDictionary _slots;

        public void Bind(SlotDefinition definition, Transform equipment)
        {
            if (_slots.ContainsKey(definition) == false)
            {
                var slot = CreateView(definition);
                _slots.Add(definition, slot);
                slot.Attach(equipment);
                return;
            }

            _slots[definition].Attach(equipment);
        }

        private EquipmentSlotView CreateView(SlotDefinition definition)
        {
            var slot = new GameObject
            {
                name = definition.Name,
                transform = { parent = transform, localPosition = Vector3.zero }
            };

            var view = slot.AddComponent<EquipmentSlotView>();

            return view;
        }
    }
}