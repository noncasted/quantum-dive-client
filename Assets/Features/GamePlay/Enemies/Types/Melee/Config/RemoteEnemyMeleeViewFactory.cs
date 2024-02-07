using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.States.Damaged.Vfx;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Entity.Views.GameObjects;
using GamePlay.Enemies.Entity.Views.HealthBars.Runtime;
using GamePlay.Enemies.Entity.Views.Hitbox.Remote;
using GamePlay.Enemies.Entity.Views.Sprites.Runtime;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Enemies.Types.Melee.States.Attack.Damages;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.Config
{
    public class RemoteEnemyMeleeViewFactory : ScopedEntityViewFactory, IEntityViewFactory
    {
        [SerializeField] private EnemyAnimatorFactory _animator;
        [SerializeField] private EnemySpriteFactory _sprite;
        [SerializeField] private EnemyTransformFactory _transform;
        [SerializeField] private EnemyObjectFactory _object;
        [SerializeField] private EnemyRemoteHitboxFactory _hitbox;
        [SerializeField] private DamagedVfxFactory _damagedVfx;
        [SerializeField] private HealthBarFactory _healthBar;
        [SerializeField] private MeleeDamageDealerFactory _damageDealer;

        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            _animator.Create(services, utils);
            _sprite.Create(services, utils);
            _transform.Create(services, utils);
            _object.Create(services, utils);
            _hitbox.Create(services, utils);
            _damagedVfx.Create(services, utils);
            _healthBar.Create(services, utils);
            _damageDealer.Create(services, utils);
        }
    }
}