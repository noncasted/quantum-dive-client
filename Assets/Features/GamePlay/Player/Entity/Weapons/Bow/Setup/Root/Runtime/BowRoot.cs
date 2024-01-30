using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime.Callbacks;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Root.Runtime
{
    public class BowRoot : IEquipment, IEntityAwakeListener
    {
        public BowRoot(
            IEntityCallbacks callbacks,
            BowSlotDefinition definition,
            IBowGameObject gameObject,
            IBowTransform transform)
        {
            _callbacks = callbacks;
            _definition = definition;
            _gameObject = gameObject;
            _transform = transform;
        }

        private readonly IEntityCallbacks _callbacks;
        private readonly BowSlotDefinition _definition;
        private readonly IBowGameObject _gameObject;
        private readonly IBowTransform _transform;

        private bool _isActive;

        public SlotDefinition Slot => _definition;
        public Transform Transform => _transform.Transform;

        public void OnAwake()
        {
            _gameObject.Disable();
        }
        
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