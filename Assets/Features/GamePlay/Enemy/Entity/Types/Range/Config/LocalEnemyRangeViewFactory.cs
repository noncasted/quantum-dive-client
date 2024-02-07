using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.States.Damaged.Vfx;
using GamePlay.Enemy.Entity.Types.Range.Views.ShootPoint;
using GamePlay.Enemy.Entity.Views.AIPaths;
using GamePlay.Enemy.Entity.Views.Animators.Runtime;
using GamePlay.Enemy.Entity.Views.GameObjects;
using GamePlay.Enemy.Entity.Views.HealthBars.Runtime;
using GamePlay.Enemy.Entity.Views.Hitbox.Local;
using GamePlay.Enemy.Entity.Views.RigidBodies.Runtime;
using GamePlay.Enemy.Entity.Views.RotationPoint.Runtime;
using GamePlay.Enemy.Entity.Views.Sprites.Runtime;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.Config
{
    public class LocalEnemyRangeViewFactory : ScopedEntityViewFactory, IEntityViewFactory
    {
        [SerializeField] private EnemyAnimatorFactory _animator;
        [SerializeField] private EnemyRotationPointFactory _rotationPoint;
        [SerializeField] private EnemySpriteFactory _sprite;
        [SerializeField] private EnemyTransformFactory _transform;
        [SerializeField] private EnemyObjectFactory _object;
        [SerializeField] private EnemyAIPathFactory _aiPath;
        [SerializeField] private EnemyLocalHitboxFactory _enemyLocalHitbox;
        [SerializeField] private DamagedVfxFactory _damagedVfx;
        [SerializeField] private EnemyRigidBodyFactory _rigidBody;
        [SerializeField] private HealthBarFactory _healthBar;
        [SerializeField] private ShootPointFactory _shootPoint;

        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            _animator.Create(services, utils);
            _rotationPoint.Create(services, utils);
            _sprite.Create(services, utils);
            _transform.Create(services, utils);
            _object.Create(services, utils);
            _aiPath.Create(services, utils);
            _enemyLocalHitbox.Create(services, utils);
            _damagedVfx.Create(services, utils);
            _rigidBody.Create(services, utils);
            _healthBar.Create(services, utils);
            _shootPoint.Create(services, utils);
        }
    }
}