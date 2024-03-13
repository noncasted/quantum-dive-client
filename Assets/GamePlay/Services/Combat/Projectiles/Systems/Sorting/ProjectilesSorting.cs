using GamePlay.Combat.Projectiles.Entity.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Systems.Sorting
{
    public class ProjectilesSorting : IEcsRunSystem
    {
        public ProjectilesSorting(ProjectileSortingConfig config)
        {
            _config = config;
            
            _mask = config.CollisionLayer;
        }

        private readonly ProjectileSortingConfig _config;
        private readonly RaycastHit2D[] _buffer = new RaycastHit2D[1];
        
        private readonly int _mask;
        
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var filter = world
                .Filter<ProjectileTransformComponent>()
                .End();

            var transformPool = world.GetPool<ProjectileTransformComponent>();

            foreach (var entity in filter)
            {
                ref var transform = ref transformPool.Get(entity);
                
                var isHit = IsHit(Vector2.up, transform.View.Position);
            }
        }

        private bool IsHit(Vector2 direction, Vector2 position)
        {
            var hit = Physics2D.RaycastNonAlloc(
                position,
                direction,
                _buffer,
                _config.RayDistance,
                _mask);

            if (hit == 0)
                return false;

            return true;
        }
    }
}