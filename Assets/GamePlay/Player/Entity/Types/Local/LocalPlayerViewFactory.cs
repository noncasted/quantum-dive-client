using GamePlay.Player.Entity.Common.Definition;
using GamePlay.Player.Entity.Components.Debug.Flags;
using GamePlay.Player.Entity.Components.Equipment.Slots.Binder;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.DamageReceivers.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Views.Hitboxes.Local;
using GamePlay.Player.Entity.Views.Physics.Runtime;
using GamePlay.Player.Entity.Views.RotationPoint.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Types.Local
{
    [DisallowMultipleComponent]
    public class LocalPlayerViewFactory : PlayerViewFactory
    {
        [SerializeField] private PlayerAnimatorFactory _animator;
        [SerializeField] private PlayerTransformFactory _transform;
        [SerializeField] private EquipmentSlotsBinderFactory _equipmentSlotsBinder;
        [SerializeField] private PlayerRotationPointFactory _rotationPoint;
        [SerializeField] private PlayerPhysicsFactory _physics;
        [SerializeField] private PlayerGameObjectFactory _gameObject;
        [SerializeField] private PlayerLocalHitboxFactory _hitbox;
        [SerializeField] private PlayerDamageReceiverFactory _damageReceiver;
        [SerializeField] private PlayerDebugFlags _debugFlags;

        public override void CreateViews(IServiceCollection services, IScopedEntityUtils utils)
        {
            _animator.Create(services, utils);
            _transform.Create(services, utils);
            _equipmentSlotsBinder.Create(services, utils);
            _rotationPoint.Create(services, utils);
            _physics.Create(services, utils);
            _gameObject.Create(services, utils);
            _hitbox.Create(services, utils);
            _damageReceiver.Create(services, utils);
            _debugFlags.Create(services, utils);
        }
    }
}