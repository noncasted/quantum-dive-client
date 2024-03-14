using GamePlay.Enemy.Entity.Common.Definition.Config;
using GamePlay.Enemy.Entity.States.Damaged.Vfx;
using GamePlay.Enemy.Entity.Types.Range.Views.ShootPoint;
using GamePlay.Enemy.Entity.Views.Animators.Runtime;
using GamePlay.Enemy.Entity.Views.GameObjects;
using GamePlay.Enemy.Entity.Views.HealthBars.Runtime;
using GamePlay.Enemy.Entity.Views.Hitbox.Remote;
using GamePlay.Enemy.Entity.Views.Sprites.Runtime;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.Config
{
    public class RemoteEnemyRangeViewFactory : EnemyViewFactory
    {
        [SerializeField] private EnemyAnimatorFactory _animator;
        [SerializeField] private EnemySpriteFactory _sprite;
        [SerializeField] private EnemyTransformFactory _transform;
        [SerializeField] private EnemyObjectFactory _object;
        [SerializeField] private EnemyRemoteHitboxFactory _hitbox;
        [SerializeField] private DamagedVfxFactory _damagedVfx;
        [SerializeField] private HealthBarFactory _healthBar;
        [SerializeField] private ShootPointFactory _shootPoint;

        public override void CreateViews(IServiceCollection services, IScopedEntityUtils utils)
        {
            _animator.Create(services, utils);
            _sprite.Create(services, utils);
            _transform.Create(services, utils);
            _object.Create(services, utils);
            _hitbox.Create(services, utils);
            _damagedVfx.Create(services, utils);
            _healthBar.Create(services, utils);
            _shootPoint.Create(services, utils);
        }
    }
}