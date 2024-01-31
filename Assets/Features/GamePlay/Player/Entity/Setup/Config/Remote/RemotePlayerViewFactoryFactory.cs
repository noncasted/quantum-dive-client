using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Slots.Binder;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Views.Hitboxes.Remote;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Config.Remote
{
    [DisallowMultipleComponent]
    public class RemotePlayerViewFactoryFactory : ScopedEntityViewFactory, IEntityViewFactory
    {
        [SerializeField] private PlayerAnimatorFactory _animator;
        [SerializeField] private PlayerSpriteFactory _sprite;
        [SerializeField] private PlayerTransformFactory _transform;
        [SerializeField] private PlayerGameObjectFactory _gameObject;
        [SerializeField] private EquipmentSlotsBinderFactory _equipmentSlotsBinder;
        [SerializeField] private PlayerRemoteHitboxFactory _hitbox;

        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            _animator.Create(services, utils);
            _sprite.Create(services, utils);
            _transform.Create(services, utils);
            _gameObject.Create(services, utils);
            _equipmentSlotsBinder.Create(services, utils);
            _hitbox.Create(services, utils);
        }
    }
}