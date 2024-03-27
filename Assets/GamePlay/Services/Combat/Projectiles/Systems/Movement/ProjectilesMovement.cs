using GamePlay.Services.Projectiles.Entity.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Systems.Movement
{
    public class ProjectilesMovement : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var filter = world
                .Filter<ProjectileMoveComponent>()
                .Inc<ProjectileTransformComponent>()
                .End();

            var movePool = world.GetPool<ProjectileMoveComponent>();
            var transformPool = world.GetPool<ProjectileTransformComponent>();

            foreach (var entity in filter)
            {
                ref var move = ref movePool.Get(entity);
                ref var transform = ref transformPool.Get(entity);
                
                var position = transform.View.Position;
                var distance = move.Speed * Time.fixedDeltaTime;
                var movePosition = position + move.Direction * distance;
                transform.View.SetPosition(movePosition);
            }
        }
    }
}