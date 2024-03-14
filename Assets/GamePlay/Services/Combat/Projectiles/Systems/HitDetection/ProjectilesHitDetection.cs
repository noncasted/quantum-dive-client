using GamePlay.Services.System.Ecs.Abstract;
using Global.Debugs.Drawing.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.Projectiles.Systems.HitDetection
{
    public class ProjectilesHitDetection : IEcsRunSystem
    {
        public ProjectilesHitDetection(
            IEntityDestroyer entityDestroyer,
            IEcsWorldProvider worldProvider,
           IShapeDrawer shapeDrawer)
        {
            _entityDestroyer = entityDestroyer;
            _worldProvider = worldProvider;
            _shapeDrawer = shapeDrawer;
        }

        private readonly IEntityDestroyer _entityDestroyer;
        private readonly IEcsWorldProvider _worldProvider;
       private readonly IShapeDrawer _shapeDrawer;

        public void Run(IEcsSystems systems)
        {
            var pools = new ProjectilePools(_worldProvider.World);

            var localEnemyHitDetection = new HitDetectionHandler(
                _entityDestroyer,
                pools,
                pools.LocalPlayerProjectiles,
                pools.EnemyHitboxes,
                _shapeDrawer,
                true);

            pools = new ProjectilePools(_worldProvider.World);

            var remoteEnemyHitDetection = new HitDetectionHandler(
                _entityDestroyer,
                pools,
                pools.RemotePlayerProjectiles,
                pools.EnemyHitboxes,
                _shapeDrawer,
                false);

            pools = new ProjectilePools(_worldProvider.World);

            var localPlayerHitDetection = new HitDetectionHandler(
                _entityDestroyer,
                pools,
                pools.EnemyProjectiles,
                pools.LocalPlayerHitboxes,
                _shapeDrawer,
                true);

            pools = new ProjectilePools(_worldProvider.World);

            var remotePlayerHitDetection = new HitDetectionHandler(
                _entityDestroyer,
                pools,
                pools.EnemyProjectiles,
                pools.RemotePlayerHitboxes,
               _shapeDrawer,
                false);

            localEnemyHitDetection.DetectHits();
            remoteEnemyHitDetection.DetectHits();

            localPlayerHitDetection.DetectHits();
            remotePlayerHitDetection.DetectHits();
        }
    }
}