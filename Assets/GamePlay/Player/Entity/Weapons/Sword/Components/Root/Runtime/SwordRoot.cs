using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Views.Transforms;
using Internal.Scopes.Abstract.Lifetimes;
using Internal.Scopes.Common.Entity;
using Internal.Scopes.Runtime.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Root.Runtime
{
    public class SwordRoot : IEquipment
    {
        public SwordRoot(
            ISwordTransform transform,
            IEntityCallbacks callbacks,
            SlotDefinition definition)
        {
            _transform = transform;
            _callbacks = callbacks;
            _definition = definition;
        }

        private readonly ISwordTransform _transform;
        private readonly IEntityCallbacks _callbacks;
        private readonly SlotDefinition _definition;

        private bool _isActive;
        private ILifetime _lifetime;

        public SlotDefinition Slot => _definition;
        public Transform Transform => _transform.Transform;

        public UniTask Construct()
        {
            return _callbacks.RunConstruct();
        }

        public async UniTask Select()
        {
            if (_isActive == true)
            {
                Debug.LogError("Sword can't be enabled twice");
                return;
            }

            _isActive = true;

            if (_lifetime != null)
                _lifetime.Terminate();

            _lifetime = new Lifetime();
            await _callbacks.RunEnable(_lifetime);
        }

        public async UniTask Deselect()
        {
            if (_isActive == false)
            {
                Debug.LogError("Sword can't be disabled twice");
                return;
            }

            _isActive = false;

            _lifetime.Terminate();
            await _callbacks.RunDisable();
        }
    }
}