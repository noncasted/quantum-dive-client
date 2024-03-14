using GamePlay.System.Ecs.Runtime.Abstract;
using Global.Debugs.Drawing.Runtime;
using Leopotam.EcsLite;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Systems.HitDetection
{
    public readonly struct HitDetectionHandler
    {
        public HitDetectionHandler(
            IEntityDestroyer destroyer,
            ProjectilePools pools,
            EcsFilter projectilesFilter,
            EcsFilter targetsFilter,
            IShapeDrawer shapeDrawer,
            bool isActive)
        {
            _destroyer = destroyer;

            _pools = pools;
            _projectilesFilter = projectilesFilter;
            _targetsFilter = targetsFilter;
            _shapeDrawer = shapeDrawer;
            _isActive = isActive;
        }

        private readonly IEntityDestroyer _destroyer;

        private readonly ProjectilePools _pools;
        private readonly EcsFilter _projectilesFilter;
        private readonly EcsFilter _targetsFilter;
        private readonly IShapeDrawer _shapeDrawer;
        private readonly bool _isActive;

        public void DetectHits()
        {
            foreach (var projectile in _projectilesFilter)
                CheckProjectile(projectile);
        }

        private void CheckProjectile(int projectile)
        {
            ref var transform = ref _pools.GetTransform(projectile);
            //ref var collider = ref _pools.GetCollider(projectile);

            var projectilePosition = transform.View.Position;
          //  var projectileRadius = collider.Radius;

            foreach (var target in _targetsFilter)
            {
                ref var targetHitbox = ref _pools.GetHitbox(target);
                var damageReceiver = targetHitbox.DamageReceiver;
                var distance = Vector2.Distance(damageReceiver.Position, projectilePosition);
                // var hitboxRadius = damageReceiver.Radius;
                //
                // //_shapeDrawer.DrawCircle(0.1f, projectilePosition, projectileRadius * 2, 1f, Color.white);
                //
                // if (distance > hitboxRadius + projectileRadius)
                //     continue;

                ref var projectileActions = ref _pools.GetActions(projectile);

                if (_isActive == true)
                {
                    // ref var projectileDamage = ref _pools.GetDamage(projectile);
                    // ref var moveHistory = ref _pools.GetMoveHistory(projectile);
                    //
                    // var direction = (moveHistory.Current - moveHistory.Previous).normalized;
                    //
                    // var damage = new Damage(
                    //     projectileDamage.Damage,
                    //     projectileDamage.PushForce,
                    //     direction);
                    //
                    // damageReceiver.ReceiveDamage(damage);
                }

                projectileActions.View.OnHit();
                _destroyer.Destroy(projectile);

                return;
            }
        }
    }
}