using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Damaged.Vfx;
using GamePlay.Enemies.Entity.Views.AIPaths;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Entity.Views.GameObjects;
using GamePlay.Enemies.Entity.Views.HealthBars.Runtime;
using GamePlay.Enemies.Entity.Views.Hitbox.Local;
using GamePlay.Enemies.Entity.Views.RigidBodies.Runtime;
using GamePlay.Enemies.Entity.Views.RotationPoint.Runtime;
using GamePlay.Enemies.Entity.Views.Sprites.Runtime;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Bootstrap.Local
{   
    public class LocalEnemyViews : MonoBehaviour, IEnemyContainerBuilder
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

        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
        {
            _animator.Create(services, callbacks);
            _rotationPoint.Create(services, callbacks);
            _sprite.Create(services, callbacks);
            _transform.Create(services, callbacks);
            _object.Create(services, callbacks);
            _aiPath.Create(services, callbacks);
            _enemyLocalHitbox.Create(services, callbacks);
            _damagedVfx.Create(services, callbacks);
            _rigidBody.Create(services, callbacks);
            _healthBar.Create(services, callbacks);
        }
    }
}