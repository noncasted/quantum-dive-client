using System;
using GamePlay.Ecs.Runtime.Bootstrap;
using GamePlay.Projectiles.Systems.CollisionDetection;
using GamePlay.Projectiles.Systems.HitDetection;
using GamePlay.Projectiles.Systems.Movement;
using GamePlay.Projectiles.Systems.Sorting;
using Internal.Scopes.Abstract.Instances.Services;

namespace GamePlay.Projectiles.Bootstrap
{
    public class ProjectilesSystemsBinder : IScopeSwitchListener
    {
        public ProjectilesSystemsBinder(
            ProjectilesCollisionDetection collisionDetection,
            ProjectilesHitDetection hitDetection,
            ProjectilesMovement movement,
            ProjectilesSorting sorting)
        {
            _collisionDetection = collisionDetection;
            _hitDetection = hitDetection;
            _movement = movement;
            _sorting = sorting;
        }

        private readonly ProjectilesCollisionDetection _collisionDetection;
        private readonly ProjectilesHitDetection _hitDetection;
        private readonly ProjectilesMovement _movement;
        private readonly ProjectilesSorting _sorting;

        private IDisposable _listener;

        public void OnEnabled()
        {
          //  _listener = Msg.Listen<EcsBootstrapEvent>(OnEcsBootstrap);
        }

        public void OnDisabled()
        {
            _listener?.Dispose();
        }

        private void OnEcsBootstrap(EcsBootstrapEvent data)
        {
            var binder = data.Binder;

            binder.AddToFixedUpdateSystems(_movement);
            binder.AddToFixedUpdateSystems(_sorting);
            binder.AddToFixedUpdateSystems(_collisionDetection);
            binder.AddToFixedUpdateSystems(_hitDetection);
        }
    }
}