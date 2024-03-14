using GamePlay.Player.Entity.Common.Definition;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Components.Debug.Flags;
using GamePlay.Player.Entity.Components.Equipment.Slots.Binder;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Views.Hitboxes.Remote;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Types.Remote
{
    [DisallowMultipleComponent]
    public class RemotePlayerViewFactory : PlayerViewFactory
    {
        [SerializeField] private PlayerAnimatorFactory _animator;
        [SerializeField] private PlayerTransformFactory _transform;
        [SerializeField] private PlayerGameObjectFactory _gameObject;
        [SerializeField] private EquipmentSlotsBinderFactory _equipmentSlotsBinder;
        [SerializeField] private PlayerRemoteHitboxFactory _hitbox;
        [SerializeField] private PlayerDebugFlags _debugFlags;

        public override void CreateViews(IServiceCollection services, IScopedEntityUtils utils)
        {
            _animator.Create(services, utils);
            _transform.Create(services, utils);
            _gameObject.Create(services, utils);
            _equipmentSlotsBinder.Create(services, utils);
            _hitbox.Create(services, utils);
            _debugFlags.Create(services, utils);
        }
    }
}