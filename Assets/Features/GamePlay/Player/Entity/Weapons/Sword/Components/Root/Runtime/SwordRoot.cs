using Common.Architecture.Entities.Runtime.Callbacks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Views.Transforms;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Root.Runtime
{
    public class SwordRoot : IEquipment
    {
        public SwordRoot(
            ISwordTransform transform,
            IEntityCallbacksRegistry callbacksRegistry,
            SlotDefinition definition)
        {
            _transform = transform;
            _callbacksRegistry = callbacksRegistry;
            _definition = definition;
        }

        private readonly ISwordTransform _transform;
        private readonly IEntityCallbacksRegistry _callbacksRegistry;
        private readonly SlotDefinition _definition;

        private bool _isActive;

        public SlotDefinition Slot => _definition;
        public Transform Transform => _transform.Transform;

        public void Select()
        {
            if (_isActive == true)
            {
                Debug.LogError("Bow can't be enabled twice");
                return;
            }

            _isActive = true;

            _callbacksRegistry.Handlers[CallbackStage.Enable].Run();
        }

        public void Deselect()
        {
            if (_isActive == false)
            {
                Debug.LogError("Bow can't be disabled twice");
                return;
            }

            _isActive = false;
            _callbacksRegistry.Handlers[CallbackStage.Disable].Run();
        }
    }
}