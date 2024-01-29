using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Projectiles.Common;
using GamePlay.Projectiles.Factory;
using GamePlay.Projectiles.Logs;
using GamePlay.Projectiles.Network;
using GamePlay.Projectiles.Pool;
using GamePlay.Projectiles.Registry.Runtime;
using GamePlay.Projectiles.Systems.CollisionDetection;
using GamePlay.Projectiles.Systems.HitDetection;
using GamePlay.Projectiles.Systems.Movement;
using GamePlay.Projectiles.Systems.Sorting;
using Internal.Services.Scenes.Data;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Projectiles.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ProjectilesRoutes.ServiceName,
        menuName = ProjectilesRoutes.ServicePath)]
    public class ProjectilesServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] [Scene] private SceneData _poolScene;

        [SerializeField] [Indent] private ProjectilesLogSettings _logSettings;
        [SerializeField] [Indent] private ProjectilesCollisionDetectionConfigAsset _collisionDetectionConfig;
        [SerializeField] [Indent] private ProjectileSortingConfig _sortingConfig;

        [SerializeField] [Indent] private ProjectileDefinitionsRegistryFactory _registry;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ProjectilesLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            services.Register<ProjectilesCollisionDetection>()
                .WithParameter(_collisionDetectionConfig)
                .AsSelf();

            services.Register<ProjectilesSorting>()
                .WithParameter(_sortingConfig)
                .AsSelf();

            services.Register<ProjectilesHitDetection>()
                .AsSelf();

            services.Register<ProjectilesMovement>()
                .AsSelf();

            services.Register<ProjectilesSystemsBinder>()
                .AsCallbackListener();

            services.Register<NetworkProjectileFactory>()
                .AsCallbackListener();

            _registry.Create(services);

            var loadResult = await utils.SceneLoader.Load(_poolScene);

            var pool = new ProjectilesPool();
            pool.CreatePools(services, loadResult.Scene, _registry.Definitions);
            utils.Callbacks.Listen(pool);

            services.Register<ProjectileFactory>()
                .As<IProjectileFactory>()
                .WithParameter<IProjectilesPool>(pool);
        }
    }
}