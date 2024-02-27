using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Combat.Projectiles.Common;
using GamePlay.Combat.Projectiles.Factory;
using GamePlay.Combat.Projectiles.Logs;
using GamePlay.Combat.Projectiles.Network;
using GamePlay.Combat.Projectiles.Pool;
using GamePlay.Combat.Projectiles.Registry.Runtime;
using GamePlay.Combat.Projectiles.Systems.CollisionDetection;
using GamePlay.Combat.Projectiles.Systems.HitDetection;
using GamePlay.Combat.Projectiles.Systems.Movement;
using GamePlay.Combat.Projectiles.Systems.Sorting;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ProjectilesRoutes.ServiceName,
        menuName = ProjectilesRoutes.ServicePath)]
    public class ProjectilesServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _poolScene;

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