using GamePlay.Combat.Projectiles.Entity.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Systems.Movement
{
    public class ProjectilesMovement : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var filter = world
                .Filter<ProjectileMoveComponent>()
                .Inc<ProjectileTransformComponent>()
                .Inc<ProjectileMoveHistoryComponent>()
                .End();

            var movePool = world.GetPool<ProjectileMoveComponent>();
            var historyPool = world.GetPool<ProjectileMoveHistoryComponent>();
            var transformPool = world.GetPool<ProjectileTransformComponent>();

            foreach (var entity in filter)
            {
                ref var move = ref movePool.Get(entity);
                ref var transform = ref transformPool.Get(entity);
                ref var history = ref historyPool.Get(entity);

                var position = transform.View.Position;
                var distance = move.Speed * Time.fixedDeltaTime;
                var movePosition = position + move.Direction * distance;
                transform.View.SetPosition(movePosition);
                history.OnPositionChanged(movePosition, distance);
            }
        }
    }
}