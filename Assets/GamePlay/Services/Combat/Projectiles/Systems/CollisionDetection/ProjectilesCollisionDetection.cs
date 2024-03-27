using GamePlay.Services.System.Ecs.Abstract;
using Leopotam.EcsLite;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Systems.CollisionDetection
{
    public class ProjectilesCollisionDetection : IEcsRunSystem
    {
        public ProjectilesCollisionDetection(
            IEntityDestroyer entityDestroyer,
            ProjectilesCollisionDetectionConfigAsset config)
        {
            _entityDestroyer = entityDestroyer;
            _mask = config.CollisionLayer;
        }

        private const float _rayDistanceMultiplier = 5f;

        private readonly Collider2D[] _buffer = new Collider2D[1];

        private readonly IEntityDestroyer _entityDestroyer;

        private readonly LayerMask _mask;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            // var filter = world
            //     .Filter<ProjectileColliderComponent>()
            //     .Inc<ProjectileMoveHistoryComponent>()
            //     .End();
            //
            // var colliderPool = world.GetPool<ProjectileColliderComponent>();
            // var moveHistoryPool = world.GetPool<ProjectileMoveHistoryComponent>();
            // var poolObjectPool = world.GetPool<ProjectileActionsComponent>();
            //
            // foreach (var entity in filter)
            // {
            //     ref var collider = ref colliderPool.Get(entity);
            //     ref var moveHistory = ref moveHistoryPool.Get(entity);
            //
            //     var middlePoint = Vector2.Lerp(moveHistory.Previous, moveHistory.Current, 0.5f);
            //
            //     var size = new Vector2(moveHistory.Distance, collider.Radius);
            //     var direction = moveHistory.Current - moveHistory.Previous; 
            //     var angle = direction.ToAngle();
            //
            //     var result = Physics2D.OverlapBoxNonAlloc(
            //         moveHistory.Current,
            //         size,
            //         angle,
            //         _buffer,
            //         _mask);
            //
            //     if (result == 0)
            //         continue;
            //     
            //     ref var poolObject = ref poolObjectPool.Get(entity);
            //
            //     if (poolObject.View.RequiresCollisionNormal == true)
            //     {
            //         var rayDistance = direction.magnitude * size.x * _rayDistanceMultiplier;
            //         
            //         var hit = Physics2D.Raycast(middlePoint, direction, rayDistance, _mask);
            //
            //         if (hit.collider != null)
            //             poolObject.View.OnCollision(hit.normal);
            //         else
            //             poolObject.View.OnCollision();
            //     }
            //     else
            //     {
            //         poolObject.View.OnCollision();
            //     }
            //
            //     _entityDestroyer.Destroy(entity);
            // }
        }
    }
}