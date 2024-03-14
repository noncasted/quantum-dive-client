using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Player.Entity.Common.Definition;
using GamePlay.Player.Entity.Types.Local;
using GamePlay.Player.Entity.Types.Remote;
using GamePlay.Player.Services.Factory.Factory.Abstract;
using GamePlay.Player.Services.Factory.Factory.Logs;
using GamePlay.Player.Services.Factory.SpawnPoints;
using GamePlay.Player.Services.List.Abstract;
using GamePlay.Services.System.Network.Objects.Factories.Abstract;
using Global.Network.Objects.Factories.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Client;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    public class PlayerFactory : IPlayerFactory, IEntityFactory, IScopeLifetimeListener
    {
        public PlayerFactory(
            IDynamicEntityFactory dynamicEntityFactory,
            INetworkFactoriesRegistry factoriesRegistry,
            IEntityScopeLoader loader,
            IPlayerList playerList,
            ISpawnPoints spawnPoints,
            LocalPlayerConfig localConfig,
            RemotePlayerConfig remoteConfig,
            LifetimeScope parentScope,
            DefaultEquipmentConfig equipment,
            PlayerFactoryLogger logger)
        {
            _dynamicEntityFactory = dynamicEntityFactory;
            _factoriesRegistry = factoriesRegistry;
            _loader = loader;
            _playerList = playerList;
            _spawnPoints = spawnPoints;
            _localConfig = localConfig;
            _remoteConfig = remoteConfig;
            _parentScope = parentScope;
            _equipment = equipment;
            _logger = logger;
        }

        private readonly IDynamicEntityFactory _dynamicEntityFactory;
        private readonly INetworkFactoriesRegistry _factoriesRegistry;
        private readonly IEntityScopeLoader _loader;
        private readonly IPlayerList _playerList;
        private readonly LocalPlayerConfig _localConfig;
        private readonly RemotePlayerConfig _remoteConfig;
        private readonly LifetimeScope _parentScope;
        private readonly DefaultEquipmentConfig _equipment;

        private readonly PlayerFactoryLogger _logger;
        private readonly GamePlayScope _scope;
        private readonly ISpawnPoints _spawnPoints;

        private readonly ObjectIdGenerator _typeGenerator = new();

        private ushort _id;

        public ushort Id => _id;

        public void OnLifetimeCreated(ILifetime lifetime)
        {
            _id = _factoriesRegistry.Register(this, lifetime);
        }

        public async UniTask<ILocalPlayerRoot> Create()
        {
            var spawnPosition = _spawnPoints.GetSpawnPosition();
            var type = _typeGenerator.Generate(Id, 1);
            var entity = _dynamicEntityFactory.Create(type);

            var view = Object.Instantiate(_localConfig.Prefab, spawnPosition, Quaternion.identity);
            var entityComponentFactory = new EntityComponentFactory(entity);
            var root = await _loader.Load<ILocalPlayerRoot>(_parentScope, view, _localConfig,
                new[] { entityComponentFactory });

            var payload = new PlayerSpawnPayload(spawnPosition);
            await _dynamicEntityFactory.Send(entity, payload);

            var player = new PlayerEntity(entity, root);
            _playerList.Add(entity.Owner, player);

            foreach (var equipment in _equipment.Equipment)
                await root.Equipper.Equip(equipment);

            await root.Callbacks.RunConstruct();
            await root.Enable();

            _logger.OnLocalInstantiated(spawnPosition);

            return root;
        }

        public async UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity)
        {
            var spawnPosition = entity.GetAttachPayload<PlayerSpawnPayload>().Position;
            var view = Object.Instantiate(_remoteConfig.Prefab, spawnPosition, Quaternion.identity);
            var entityComponentFactory = new EntityComponentFactory(entity);
            var root = await _loader.Load<IPlayerRoot>(_parentScope, view, _remoteConfig,
                new[] { entityComponentFactory });

            var player = new PlayerEntity(entity, root);
            _playerList.Add(entity.Owner, player);
 
            await root.Callbacks.RunConstruct();
            await root.Enable();

            _logger.OnRemoteInstantiated(spawnPosition);
        }
    }
}