using System;
using Common.DataTypes.Structs;
using GamePlay.Ecs.Runtime.Abstract;
using GamePlay.Hitboxes.Flags;
using GamePlay.Projectiles.Entity.Components;
using GamePlay.Projectiles.Pool;

namespace GamePlay.Projectiles.Factory
{
    public class ProjectileFactory : IProjectileFactory
    {
        public ProjectileFactory(
            IProjectilesPool pool,
            IEntityCreator entityCreator,
            IEntityComponentSetter componentSetter)
        {
            _pool = pool;
            _entityCreator = entityCreator;
            _componentSetter = componentSetter;
        }

        private readonly IEntityComponentSetter _componentSetter;
        private readonly IProjectilesPool _pool;
        private readonly IEntityCreator _entityCreator;
        
        public event Action<ProjectileRequest> PlayerProjectileCreated;
        public event Action<ProjectileRequest> EnemyProjectileCreated;

        public void CreateLocalPlayer(ProjectileRequest request)
        {
            var projectile = CreateProjectile(request);

            _componentSetter.Add<LocalFlag>(projectile);
            _componentSetter.Add<PlayerFlag>(projectile);

            PlayerProjectileCreated?.Invoke(request);
        }

        public void CreateRemotePlayer(ProjectileRequest request)
        {
            var projectile = CreateProjectile(request);

            _componentSetter.Add<RemoteFlag>(projectile);
            _componentSetter.Add<PlayerFlag>(projectile);
        }

        public void CreateLocalEnemy(ProjectileRequest request)
        {
            var projectile = CreateProjectile(request);

            _componentSetter.Add<EnemyFlag>(projectile);
            
            EnemyProjectileCreated?.Invoke(request);
        }

        public void CreateRemoteEnemy(ProjectileRequest request)
        {
            var projectile = CreateProjectile(request);

            _componentSetter.Add<EnemyFlag>(projectile);
        }

        private int CreateProjectile(ProjectileRequest request)
        {
            var position = request.Position;
            var parameters = request.Parameters;
            var direction = request.Direction;
            
            var projectileObject = _pool.Get(request.Definition, position);

            var angle = direction.ToAngle();
            projectileObject.Transform.SetRotation(angle);

            var entity = _entityCreator.CreateEntity();

            ref var damageComponent = ref _componentSetter.Add<ProjectileDamageComponent>(entity);
            ref var transformComponent = ref _componentSetter.Add<ProjectileTransformComponent>(entity);
            ref var spriteComponent = ref _componentSetter.Add<ProjectileSpriteComponent>(entity);
            ref var colliderComponent = ref _componentSetter.Add<ProjectileColliderComponent>(entity);
            ref var moveComponent = ref _componentSetter.Add<ProjectileMoveComponent>(entity);
            ref var moveHistoryComponent = ref _componentSetter.Add<ProjectileMoveHistoryComponent>(entity);
            ref var poolObjectComponent = ref _componentSetter.Add<ProjectileActionsComponent>(entity);
            
            damageComponent.Construct(parameters.Damage, parameters.PushForce);
            transformComponent.Construct(projectileObject.Transform);
            spriteComponent.Construct(projectileObject.Sprite);
            colliderComponent.Construct(parameters.Radius);
            moveComponent.Construct(direction, parameters.Speed);
            moveHistoryComponent.Construct(position);
            poolObjectComponent.Construct(projectileObject.Actions);

            projectileObject.Actions.OnTaken();
            
            return entity;
        }
    }
}