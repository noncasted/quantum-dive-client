using Common.Architecture.Entities.Factory;
using Common.Architecture.Entities.Runtime;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Player.Entity.Setup.Config.Local;
using GamePlay.Player.Entity.Setup.Config.Remote;
using GamePlay.Player.Entity.Setup.Root.Common;
using GamePlay.Player.Entity.Setup.Root.Local;
using GamePlay.Player.Services.Factory.Factory.Logs;
using GamePlay.Player.Services.Factory.SpawnPoints;
using GamePlay.Player.Services.List.Definition;
using GamePlay.Player.Services.List.Runtime;
using GamePlay.Player.Services.Provider.Runtime;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    public class PlayerFactory : IPlayerFactory, IEntityFactory, IScopeSwitchListener
    {
        public PlayerFactory(
            IDynamicEntityFactory dynamicEntityFactory,
            INetworkFactoriesRegistry factoriesRegistry,
            IEntityCreator creator,
            IPlayersList playersList, 
            IPlayerProvider playerProvider,
            LocalPlayerConfig localConfig,
            RemotePlayerConfig remoteConfig,
            LifetimeScope parentScope,
            DefaultEquipmentConfig equipment,
            PlayerFactoryLogger logger)
        {
            _dynamicEntityFactory = dynamicEntityFactory;
            _factoriesRegistry = factoriesRegistry;
            _creator = creator;
            _playersList = playersList;
            _playerProvider = playerProvider;
            _localConfig = localConfig;
            _remoteConfig = remoteConfig;
            _parentScope = parentScope;
            _equipment = equipment;
            _logger = logger;
        }

        private readonly IDynamicEntityFactory _dynamicEntityFactory;
        private readonly INetworkFactoriesRegistry _factoriesRegistry;
        private readonly IEntityCreator _creator;
        private readonly IPlayersList _playersList;
        private readonly IPlayerProvider _playerProvider;
        private readonly LocalPlayerConfig _localConfig;
        private readonly RemotePlayerConfig _remoteConfig;
        private readonly LifetimeScope _parentScope;
        private readonly DefaultEquipmentConfig _equipment;

        private readonly PlayerFactoryLogger _logger;
        private readonly LevelScope _scope;
        private readonly ISpawnPoints _spawnPoints;

        private readonly ObjectIdGenerator _typeGenerator = new();

        private ushort _id;

        public ushort Id => _id;

        public void AssignId(ushort id)
        {
            _id = id;
        }

        public void OnEnabled()
        {
            _factoriesRegistry.Register(this);
        }

        public void OnDisabled()
        {
            _factoriesRegistry.Unregister(this);
        }

        public async UniTask<ILocalPlayerRoot> Create()
        {
            var spawnPosition = _spawnPoints.GetSpawnPosition();
            var type = _typeGenerator.Generate(Id, 1);
            var entity = _dynamicEntityFactory.Create(type);

            var view = Object.Instantiate(_localConfig.Prefab, spawnPosition, Quaternion.identity);
            var entityComponentFactory = new EntityComponentFactory(entity);
            var root = await _creator.Create<ILocalPlayerRoot>(_parentScope, view, _localConfig, new[] { entityComponentFactory });
            
            var payload = new PlayerSpawnPayload(spawnPosition);
            await _dynamicEntityFactory.Send(entity, payload);
            
            var player = new NetworkPlayer(entity, root);
            _playersList.Add(entity.Owner, player);

            foreach (var equipment in _equipment.Equipment)
                root.Equipper.Equip(equipment);

            _logger.OnLocalInstantiated(spawnPosition);
            
            return root;
        }
        
        public async UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity)
        {
            var spawnPosition = entity.GetAttachPayload<PlayerSpawnPayload>().Position;
            var view = Object.Instantiate(_remoteConfig.Prefab, spawnPosition, Quaternion.identity);
            var entityComponentFactory = new EntityComponentFactory(entity);
            var root = await _creator.Create<IPlayerRoot>(_parentScope, view, _remoteConfig, new[] { entityComponentFactory });

            var player = new NetworkPlayer(entity, root);
            _playersList.Add(entity.Owner, player);
            
            _logger.OnRemoteInstantiated(spawnPosition);
        }
    }
}