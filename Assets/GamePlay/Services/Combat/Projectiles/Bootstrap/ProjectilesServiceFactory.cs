using Cysharp.Threading.Tasks;
using GamePlay.Services.Projectiles.Common;
using GamePlay.Services.Projectiles.Factory;
using GamePlay.Services.Projectiles.Network;
using GamePlay.Services.Projectiles.Pool;
using GamePlay.Services.Projectiles.Registry.Runtime;
using GamePlay.Services.Projectiles.Systems.CollisionDetection;
using GamePlay.Services.Projectiles.Systems.HitDetection;
using GamePlay.Services.Projectiles.Systems.Movement;
using GamePlay.Services.Projectiles.Systems.Sorting;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ProjectilesRoutes.ServiceName,
        menuName = ProjectilesRoutes.ServicePath)]
    public class ProjectilesServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private SceneData _poolScene;

        [SerializeField] [Indent] private ProjectilesCollisionDetectionConfigAsset _collisionDetectionConfig;
        [SerializeField] [Indent] private ProjectileSortingConfig _sortingConfig;

        [SerializeField] [Indent] private ProjectileDefinitionsRegistryFactory _registry;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
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