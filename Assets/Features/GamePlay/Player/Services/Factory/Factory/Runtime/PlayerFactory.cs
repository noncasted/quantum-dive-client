using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Players.Registry.Runtime;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.Lifecycle.Runtime;
using GamePlay.Player.Entity.Setup.Bootstrap.Local;
using GamePlay.Player.Entity.Setup.Bootstrap.Remote;
using GamePlay.Player.Entity.Setup.Root.Local;
using GamePlay.Player.Services.Factory.Factory.Logs;
using GamePlay.Player.Services.Factory.SpawnPoints;
using GamePlay.Player.Services.Provider.Runtime;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    public class PlayerFactory : IPlayerFactory, IEntityFactory, IScopeSwitchListener
    {
        public PlayerFactory(
            LevelScope scope,
            ISpawnPoints spawnPoints,
            IPlayerProvider provider,
            IRoomLifecycle roomLifecycle,
            INetworkFactoriesRegistry factoriesRegistry,
            IDynamicEntityFactory dynamicEntityFactory,
            IPlayersRegistry playersRegistry,
            DefaultEquipmentConfig equipment,
            PlayerPrefabs prefabs,
            PlayerFactoryLogger logger)
        {
            _provider = provider;
            _roomLifecycle = roomLifecycle;
            _factoriesRegistry = factoriesRegistry;
            _dynamicEntityFactory = dynamicEntityFactory;
            _playersRegistry = playersRegistry;
            _equipment = equipment;
            _prefabs = prefabs;
            _logger = logger;
            _spawnPoints = spawnPoints;
            _scope = scope;
        }

        private readonly IPlayerProvider _provider;
        private readonly IRoomLifecycle _roomLifecycle;
        private readonly INetworkFactoriesRegistry _factoriesRegistry;
        private readonly IDynamicEntityFactory _dynamicEntityFactory;
        private readonly IPlayersRegistry _playersRegistry;
        private readonly DefaultEquipmentConfig _equipment;
        private readonly PlayerPrefabs _prefabs;

        private readonly PlayerFactoryLogger _logger;
        private readonly LevelScope _scope;
        private readonly ISpawnPoints _spawnPoints;

        private readonly ObjectIdGenerator _typeGenerator = new();

        private ushort _id;

        public ushort Id => _id;


        public async UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity)
        {
        }

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

        public async UniTask<IPlayerRoot> Create()
        {
            var spawnPosition = _spawnPoints.GetSpawnPosition();
            var playerObject = Object.Instantiate(_prefabs.Local);

            playerObject.name = "Player_Local";

            _logger.OnLocalInstantiated(spawnPosition);

            var bootstrapper = playerObject.GetComponent<ILocalPlayerBootstrapper>();

            var type = _typeGenerator.Generate(Id, 1);
            var payload = new PlayerSpawnPayload(spawnPosition);
            var entity = _dynamicEntityFactory.Create(type);
            var entityHandler = new PlayerAttachHandler(_roomLifecycle, entity, payload);

            var root = await bootstrapper.Bootstrap(_scope, entityHandler);

            _provider.AssignPlayer(root.Position, root.Health);

            foreach (var equipment in _equipment.Equipment)
                root.Equipper.Equip(equipment);

            return root;
        }

        public async UniTaskVoid CreateRemote(int objectId, RagonEntity entity)
        {
            var playerObject = Object.Instantiate(_prefabs.Remote, Vector2.zero, Quaternion.identity);

            playerObject.name = "Player_Remote";

            var bootstrapper = playerObject.GetComponent<IRemotePlayerBootstrapper>();
            var root = await bootstrapper.Bootstrap(_scope, entity);

            var awaiter = new AttachAwaiter(entity);
            await awaiter.WaitAttachAsync();

            root.OnEntityAttached();

            //     var payload = entity.GetSpawnPayload<PlayerSpawnPayload>();
            //     var spawnPosition = payload.Position;
            //     playerObject.transform.position = spawnPosition;
            //     _logger.OnRemoteInstantiated(spawnPosition);
            //
            //     var data = new RemotePlayerData(entity, root);
            //     
            //     _playersRegistry.Add(entity.Owner, data);
        }
    }
}