using GamePlay.Combat.Hitboxes.Flags;
using GamePlay.Combat.Hitboxes.Runtime;
using GamePlay.Combat.Projectiles.Entity.Components;
using Leopotam.EcsLite;

namespace GamePlay.Combat.Projectiles.Systems.HitDetection
{
    public class ProjectilePools
    {
        public ProjectilePools(EcsWorld world)
        {
            _actionsPool = world.GetPool<ProjectileActionsComponent>();
            _colliderPool = world.GetPool<ProjectileColliderComponent>();
            _damagePool = world.GetPool<ProjectileDamageComponent>();
            _transformPool = world.GetPool<ProjectileTransformComponent>();
            _hitboxPool = world.GetPool<HitboxComponent>();
            _moveHistoryPool = world.GetPool<ProjectileMoveHistoryComponent>();

            LocalPlayerProjectiles = world
                .Filter<ProjectileActionsComponent>()
                .Inc<ProjectileColliderComponent>()
                .Inc<ProjectileDamageComponent>()
                .Inc<ProjectileTransformComponent>()
                .Inc<PlayerFlag>()
                .Inc<LocalFlag>()
                .End();

            RemotePlayerProjectiles = world
                .Filter<ProjectileActionsComponent>()
                .Inc<ProjectileColliderComponent>()
                .Inc<ProjectileDamageComponent>()
                .Inc<ProjectileTransformComponent>()
                .Inc<PlayerFlag>()
                .Inc<RemoteFlag>()
                .End();

            EnemyProjectiles = world
                .Filter<ProjectileActionsComponent>()
                .Inc<ProjectileColliderComponent>()
                .Inc<ProjectileDamageComponent>()
                .Inc<ProjectileTransformComponent>()
                .Inc<EnemyFlag>()
                .End();

            LocalPlayerHitboxes = world
                .Filter<HitboxComponent>()
                .Inc<PlayerFlag>()
                .Inc<LocalFlag>()
                .End();

            RemotePlayerHitboxes = world
                .Filter<HitboxComponent>()
                .Inc<PlayerFlag>()
                .Inc<RemoteFlag>()
                .End();

            EnemyHitboxes = world
                .Filter<HitboxComponent>()
                .Inc<EnemyFlag>()
                .End();
        }

        private readonly EcsPool<ProjectileActionsComponent> _actionsPool;
        private readonly EcsPool<ProjectileColliderComponent> _colliderPool;
        private readonly EcsPool<ProjectileDamageComponent> _damagePool;
        private readonly EcsPool<ProjectileTransformComponent> _transformPool;
        private readonly EcsPool<ProjectileMoveHistoryComponent> _moveHistoryPool;

        private readonly EcsPool<HitboxComponent> _hitboxPool;

        public readonly EcsFilter LocalPlayerProjectiles;
        public readonly EcsFilter RemotePlayerProjectiles;
        public readonly EcsFilter EnemyProjectiles;
        public readonly EcsFilter LocalPlayerHitboxes;
        public readonly EcsFilter RemotePlayerHitboxes;
        public readonly EcsFilter EnemyHitboxes;

        public ref ProjectileActionsComponent GetActions(int entity)
        {
            return ref _actionsPool.Get(entity);
        }

        public ref ProjectileColliderComponent GetCollider(int entity)
        {
            return ref _colliderPool.Get(entity);
        }

        public ref ProjectileDamageComponent GetDamage(int entity)
        {
            return ref _damagePool.Get(entity);
        }

        public ref ProjectileTransformComponent GetTransform(int entity)
        {
            return ref _transformPool.Get(entity);
        }

        public ref HitboxComponent GetHitbox(int entity)
        {
            return ref _hitboxPool.Get(entity);
        }

        public ref ProjectileMoveHistoryComponent GetMoveHistory(int entity)
        {
            return ref _moveHistoryPool.Get(entity);
        }
    }
}