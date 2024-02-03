using System;
using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Common.Scope;
using GamePlay.Ecs.Runtime.Bootstrap;
using GamePlay.Enemies.Services.Network.DataBridges.States.Runtime;
using GamePlay.Enemies.Services.Registry.Runtime;
using GamePlay.Enemies.Services.Spawn.Factory.Runtime;
using GamePlay.Enemies.Services.Spawn.Pool.Runtime;
using GamePlay.Enemies.Services.Spawn.Registry.Runtime;
using GamePlay.Enemies.Services.Updater.Runtime;
using GamePlay.Enemies.Tests.Common;
using GamePlay.Hitboxes.Runtime;
using GamePlay.Network.Objects.Destroyer.Runtime;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.Lifecycle.Runtime;
using GamePlay.Network.Room.SceneCollectors.Runtime;
using GamePlay.Player.List.Runtime;
using GamePlay.Projectiles.Bootstrap;
using GamePlay.Targets.Registry.Runtime;
using GamePlay.VfxPools.Runtime;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer.Unity;

namespace GamePlay.Enemies.Tests.States
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "StatesTestSceneAsset", menuName = EnemyTestsAssetsPaths.Root + "StatesScene")]
    public class EnemyStatesTestAsset : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("System")] [SerializeField]
        private EcsFactory _ecs;

        [FoldoutGroup("System")] [SerializeField]
        private ProjectilesServiceFactory _projectiles;

        [FoldoutGroup("System")] [SerializeField]
        private VfxPoolFactory _vfxPool;

        [FoldoutGroup("System")] [SerializeField]
        private HitboxRegistryFactory _hitboxRegistry;

        [FoldoutGroup("System")] [SerializeField]
        private TargetRegistryFactory _targetRegistry;

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

        [FormerlySerializedAs("_enemiesRegistry")] [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyListFactory _enemyList;

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
            _projectiles,
            _vfxPool,
            _enemyPool,
            _ecs,
            _hitboxRegistry,
            _targetRegistry,
            _roomStarter,
            _entityDestroyer,
            _factoriesRegistry,
            _sceneEntityFactory,
            _sceneCollector,
            _dynamicEntityFactory,
            _playersRegistry,
            _enemyList,
            _enemyFactory,
            _enemyDefinitionsRegistry,
            _enemyStateDefinitionsRegistry,
            _enemyUpdater,
        };

        public IReadOnlyList<IServicesCompose> Composes => Array.Empty<IServicesCompose>();
    }
}