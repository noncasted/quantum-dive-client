using Common.Architecture.Entities.Runtime.Callbacks;
using Features.GamePlay.Player.Entity.Weapons.Sword.Views.Transforms;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Runtime
{
    public class SwordRoot : IEquipment
    {
        public SwordRoot(
            ISwordTransform transform,
            IEntityCallbacks callbacks,
            SwordSlotDefinition definition)
        {
            _transform = transform;
            _callbacks = callbacks;
            _definition = definition;
        }

        private readonly ISwordTransform _transform;
        private readonly IEntityCallbacks _callbacks;
        private readonly SwordSlotDefinition _definition;

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

            _callbacks.Handlers[CallbackStage.Enable].Run();
        }

        public void Deselect()
        {
            if (_isActive == false)
            {
                Debug.LogError("Bow can't be disabled twice");
                return;
            }

            _isActive = false;
            _callbacks.Handlers[CallbackStage.Disable].Run();
        }
    }
}