using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Internal.Scopes.Common.Entity;
using Internal.Scopes.Runtime.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Root.Runtime
{
    public class BowRoot : IEquipment, IEntityAwakeListener
    {
        public BowRoot(
            IEntityCallbacks callbacks,
            SlotDefinition definition,
            IBowGameObject gameObject,
            IBowTransform transform)
        {
            _callbacks = callbacks;
            _definition = definition;
            _gameObject = gameObject;
            _transform = transform;
            
        }

        private readonly IEntityCallbacks _callbacks;
        private readonly SlotDefinition _definition;
        private readonly IBowGameObject _gameObject;
        private readonly IBowTransform _transform;

        private bool _isActive;
        private ILifetime _lifetime;

        public SlotDefinition Slot => _definition;
        public Transform Transform => _transform.Transform;

        public void OnAwake()
        {
        }

        public UniTask Construct()
        {
            return _callbacks.RunConstruct();
        }

        public async UniTask Select()
        {
            if (_isActive == true)
            {
                Debug.LogError("Bow can't be enabled twice");
                return;
            }

            _isActive = true;

            if (_lifetime != null)
                await _lifetime.Terminate();

            _lifetime = new Lifetime();
            await _callbacks.RunEnable(_lifetime);
        }

        public async UniTask Deselect()
        {
            if (_isActive == false)
            {
                Debug.LogError("Bow can't be disabled twice");
                return;
            }

            _isActive = false;

            await _lifetime.Terminate();
            await _callbacks.RunDisable();
        }
    }
}