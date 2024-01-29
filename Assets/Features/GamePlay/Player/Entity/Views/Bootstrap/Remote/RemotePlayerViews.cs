using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Views.Hitboxes.Remote;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Bootstrap.Remote
{
    [DisallowMultipleComponent]
    public class RemotePlayerViews : MonoBehaviour, IPlayerContainerBuilder
    {
        [SerializeField] private PlayerAnimatorFactory _animator;
        [SerializeField] private PlayerSpriteFactory _sprite;
        [SerializeField] private PlayerTransformFactory _transform;
        [SerializeField] private PlayerGameObjectFactory _gameObject;
        [SerializeField] private PlayerEquipmentSlotsBinderFactory _equipmentSlotsBinder;
        [SerializeField] private PlayerRemoteHitboxFactory _hitbox;

        public void OnBuild(IServiceCollection services, ICallbackRegister callbackRegister)
        {
            _animator.Create(services, callbackRegister);
            _sprite.Create(services, callbackRegister);
            _transform.Create(services, callbackRegister);
            _gameObject.Create(services, callbackRegister);
            _equipmentSlotsBinder.Create(services, callbackRegister);
            _hitbox.Create(services, callbackRegister);
        }
    }
}