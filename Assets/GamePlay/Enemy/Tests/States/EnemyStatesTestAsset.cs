using System;
using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Combat.Hitboxes.Runtime;
using GamePlay.Combat.Projectiles.Bootstrap;
using GamePlay.Combat.Targets.Registry.Runtime;
using GamePlay.Common.Scope;
using GamePlay.Enemy.List.Runtime;
using GamePlay.Enemy.Mappers.Definitions.Runtime;
using GamePlay.Enemy.Mappers.States.Runtime;
using GamePlay.Enemy.Spawn.Factory.Runtime;
using GamePlay.Enemy.Spawn.Pool.Runtime;
using GamePlay.Enemy.Tests.Common;
using GamePlay.Enemy.Updater.Runtime;
using GamePlay.Player.List.Runtime;
using GamePlay.System.Ecs.Runtime.Bootstrap;
using GamePlay.System.Network.Objects.Destroyer.Runtime;
using GamePlay.System.Network.Objects.Factories.Registry;
using GamePlay.System.Network.Objects.Factories.Runtime;
using GamePlay.System.Network.Room.Entities.Factory;
using GamePlay.System.Network.Room.Lifecycle.Runtime;
using GamePlay.System.Network.Room.SceneCollectors.Runtime;
using GamePlay.Visuals.VfxPools.Runtime;
using Internal.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer.Unity;

namespace GamePlay.Enemy.Tests.States
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

        [FormerlySerializedAs("_playersRegistry")] [FoldoutGroup("Network")] [SerializeField]
        private PlayerListFactory _playerList;

        [FormerlySerializedAs("_enemiesRegistry")] [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyListFactory _enemyList;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyFactoryServiceFactory _enemyFactory;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyPoolFactory _enemyPool;

        [FormerlySerializedAs("_enemyDefinitionsRegistry")] [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyDefinitionMapperFactory _enemyDefinitionMapper;

        [FormerlySerializedAs("_enemyStateDefinitionsRegistry")] [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyStateMapperFactory _enemyStateMapper;

        [FoldoutGroup("Enemy")] [SerializeField]
        private EnemyUpdaterFactory _enemyUpdater;

        [SerializeField] private GamePlayScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;
        [SerializeField] private bool _isMock;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public bool IsMock => _isMock;

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
            _playerList,
            _enemyList,
            _enemyFactory,
            _enemyDefinitionMapper,
            _enemyStateMapper,
            _enemyUpdater,
        };

        public IReadOnlyList<IServicesCompose> Composes => Array.Empty<IServicesCompose>();
    }
}