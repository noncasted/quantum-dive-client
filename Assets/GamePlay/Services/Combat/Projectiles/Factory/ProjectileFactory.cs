using System;
using GamePlay.Services.Hitboxes.Flags;
using GamePlay.Services.Projectiles.Entity.Components;
using GamePlay.Services.Projectiles.Pool;
using GamePlay.Services.System.Ecs.Abstract;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Factory
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

            var angle = MathF.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            projectileObject.Transform.SetRotation(angle);

            var entity = _entityCreator.CreateEntity();

            ref var damageComponent = ref _componentSetter.Add<ProjectileDamageComponent>(entity);
            ref var transformComponent = ref _componentSetter.Add<ProjectileTransformComponent>(entity);
            ref var moveComponent = ref _componentSetter.Add<ProjectileMoveComponent>(entity);
            ref var poolObjectComponent = ref _componentSetter.Add<ProjectileActionsComponent>(entity);
            
            damageComponent.Construct(parameters.Damage, parameters.PushForce);
            transformComponent.Construct(projectileObject.Transform);
            moveComponent.Construct(direction, parameters.Speed);
            poolObjectComponent.Construct(projectileObject.Actions);

            projectileObject.Actions.OnTaken();
            
            return entity;
        }
    }
}