using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Damaged.Vfx;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Entity.Views.GameObjects;
using GamePlay.Enemies.Entity.Views.HealthBars.Runtime;
using GamePlay.Enemies.Entity.Views.Hitbox.Remote;
using GamePlay.Enemies.Entity.Views.Sprites.Runtime;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Bootstrap.Remote
{
    public class RemoteEnemyView : MonoBehaviour, IEnemyContainerBuilder
    {
        [SerializeField] private EnemyAnimatorFactory _animator;
        [SerializeField] private EnemySpriteFactory _sprite;
        [SerializeField] private EnemyTransformFactory _transform;
        [SerializeField] private EnemyObjectFactory _object;
        [SerializeField] private EnemyRemoteHitboxFactory _hitbox;
        [SerializeField] private DamagedVfxFactory _damagedVfx;
        [SerializeField] private HealthBarFactory _healthBar;

        public void OnBuild(IServiceCollection services, ICallbackRegistry callbacks)
        {
            _animator.Create(services, callbacks);
            _sprite.Create(services, callbacks);
            _transform.Create(services, callbacks);
            _object.Create(services, callbacks);
            _hitbox.Create(services, callbacks);
            _damagedVfx.Create(services, callbacks);
            _healthBar.Create(services, callbacks);
        }
    }
}