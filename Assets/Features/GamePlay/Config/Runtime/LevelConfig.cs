using System;
using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Common.Paths;
using GamePlay.Common.Scope;
using GamePlay.Ecs.Runtime.Bootstrap;
using GamePlay.Enemies.Services.Network.DataBridges.States.Runtime;
using GamePlay.Enemies.Services.Registry.Runtime;
using GamePlay.Enemies.Services.Spawn.Factory.Runtime;
using GamePlay.Enemies.Services.Spawn.Pool.Runtime;
using GamePlay.Enemies.Services.Spawn.Registry.Runtime;
using GamePlay.Enemies.Services.Updater.Runtime;
using GamePlay.Environment.Bootstrap;
using GamePlay.Hitboxes.Runtime;
using GamePlay.LevelCameras.Runtime;
using GamePlay.Loop.Runtime;
using GamePlay.Network.Objects.Destroyer.Runtime;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.Lifecycle.Runtime;
using GamePlay.Network.Room.SceneCollectors.Runtime;
using GamePlay.Player.Services.Factory.Factory.Runtime;
using GamePlay.Player.Services.List.Runtime;
using GamePlay.Player.Services.Provider.Runtime;
using GamePlay.Player.Services.Registries.Equipment.Runtime;
using GamePlay.Player.Services.Registries.States.Runtime;
using GamePlay.Player.UI.Overlay.Runtime.Bootstrap;
using GamePlay.Projectiles.Bootstrap;
using GamePlay.Targets.Registry.Runtime;
using GamePlay.VfxPools.Runtime;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class LevelConfig : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("System")] [SerializeField]
        private EcsFactory _ecs;

        [FoldoutGroup("System")] [SerializeField]
        private LevelLoopFactory _levelLoop;

        [FoldoutGroup("System")] [SerializeField]
        private ProjectilesServiceFactory _projectiles;

        [FoldoutGroup("System")] [SerializeField]
        private VfxPoolFactory _vfxPool;

        [FoldoutGroup("System")] [SerializeField]
        private HitboxRegistryFactory _hitboxRegistry;

        [FoldoutGroup("System")] [SerializeField]
        private TargetRegistryFactory _targetRegistry;

        [FoldoutGroup("Level")] [SerializeField]
        private LevelEnvironmentBaseFactory _environment;

        [FoldoutGroup("Level")] [SerializeField]
        private LevelCameraFactory _levelCamera;

        [FoldoutGroup("Player")] [SerializeField]
        private PlayerFactoryServiceFactory _playerFactory;

        [FoldoutGroup("Player")] [SerializeField]
        private PlayerProviderFactory _playerProvider;

        [FoldoutGroup("Player")] [SerializeField]
        private EquipmentRegistryFactory _equipmentRegistry;

        [FoldoutGroup("Player")] [SerializeField]
        private StateDefinitionsRegistryFactory _statesRegistry;

        [FoldoutGroup("Player")] [SerializeField]
        private PlayerOverlayFactory _playerOverlay;

        [FoldoutGroup("Network")] [SerializeField]
        private RoomStarterBaseFactory _roomStarter;

        [FoldoutGroup("Network")] [SerializeField]
        private NetworkEntityDestroyerFactory _entityDestroyer;

        [FoldoutGroup("Network")] [SerializeField]
        private NetworkFactoriesRegistryFactory _factoriesRegistry;

        [FoldoutGroup("Network")] [SerializeField]
        private SceneEntityFactoryServiceFactory _sceneEntityFactory;

        [FoldoutGroup("Network")] [SerializeField]
        private NetworkSceneCollectorFactory _sceneCollector;

        [FoldoutGroup("Network")] [SerializeField]
        private DynamicEntityFactoryServiceFactory _dynamicEntityFactory;

        [FoldoutGroup("Network")] [SerializeField]
        private PlayersRegistryFactory _playersRegistry;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemiesRegistryFactory _enemiesRegistry;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyFactoryServiceFactory _enemyFactory;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyPoolFactory _enemyPool;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyDefinitionsRegistryFactory _enemyDefinitionsRegistry;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyStateDefinitionsRegistryFactory _enemyStateDefinitionsRegistry;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyUpdaterFactory _enemyUpdater;

        [SerializeField] private LevelScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;


        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;


        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _levelCamera,
            _levelLoop,
            _ecs,
            _hitboxRegistry,
            _playerFactory,
            _playerProvider,
            _equipmentRegistry,
            _statesRegistry,
            _targetRegistry,

            _roomStarter,
            _entityDestroyer,
            _factoriesRegistry,
            _sceneEntityFactory,
            _sceneCollector,
            _dynamicEntityFactory,
            _playersRegistry,

            _enemiesRegistry,
            _enemyFactory,
            _enemyDefinitionsRegistry,
            _enemyStateDefinitionsRegistry,
            _enemyUpdater,
            _projectiles,
            _vfxPool,
            _environment,
            _playerOverlay,

            _enemyPool
        };

        public IReadOnlyList<IServicesCompose> Composes => Array.Empty<IServicesCompose>();
    }
}