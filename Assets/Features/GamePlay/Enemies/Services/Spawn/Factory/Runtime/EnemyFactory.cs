using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;
using GamePlay.Enemies.Services.Spawn.Factory.Logs;
using GamePlay.Enemies.Services.Spawn.Pool.Runtime;
using GamePlay.Enemies.Services.Spawn.Registry.Runtime;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Room.Lifecycle.Runtime;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Factory.Runtime
{
    public class EnemyFactory : IEnemyFactory, IEntityFactory, IScopeSwitchListener
    {
        public EnemyFactory(
            INetworkFactoriesRegistry factoriesRegistry,
            IDynamicEntityFactory dynamicEntityFactory,
            IRoomLifecycle roomLifecycle,
            IEnemyPool pool,
            IEnemyDefinitionsRegistry definitionsRegistry,
            EnemyFactoryLogger logger)
        {
            _factoriesRegistry = factoriesRegistry;
            _dynamicEntityFactory = dynamicEntityFactory;
            _roomLifecycle = roomLifecycle;
            _pool = pool;
            _definitionsRegistry = definitionsRegistry;
            _logger = logger;
        }
        
        private readonly INetworkFactoriesRegistry _factoriesRegistry;
        private readonly IDynamicEntityFactory _dynamicEntityFactory;
        private readonly IRoomLifecycle _roomLifecycle;
        private readonly IEnemyPool _pool;
        private readonly IEnemyDefinitionsRegistry _definitionsRegistry;
        private readonly EnemyFactoryLogger _logger;

        private readonly ObjectIdGenerator _typeGenerator = new();

        private ushort _id;

        public ushort Id => _id;   
        
        public void OnEnabled()
        {
            _factoriesRegistry.Register(this);
        }
        
        public void OnDisabled()
        {
            _factoriesRegistry.Unregister(this);
        }

        public async UniTask CreateAsync(IEnemyDefinition definition, Vector2 position)
        {
            var root = await _pool.GetLocal(definition, position);
                                                
            var type = _typeGenerator.Generate(Id, definition.Id);
            var payload = new EnemySpawnPayload(position);
            var entity = _dynamicEntityFactory.Create(type);
            
            root.OnBeforeAttach(entity);

            var awaiter = new LocalAttachAwaiter(_roomLifecycle, entity, payload);
            await awaiter.SendToNetwork();
            
            root.OnAttached().Forget();

            _logger.OnLocal(definition.Name, position);
        }
        
        public async UniTaskVoid CreateRemote(int objectId, RagonEntity entity)
        {
            var prefabId = _typeGenerator.GetPrefabId(objectId);
            var definition = _definitionsRegistry.GetDefinition(prefabId.ObjectId);
            var root = await _pool.GetRemote(definition, Vector2.zero);

            root.OnBeforeAttach(entity);

            var awaiter = new RemoteAttachAwaiter(entity);
            await awaiter.AwaitAttach();

          //  var payload = entity.GetSpawnPayload<EnemySpawnPayload>();
        //     root.GameObject.transform.position = payload.Position;
        //     
        //     root.OnAttached();
        //
        //     _logger.OnRemote(definition.Name, payload.Position);
         }

        public async UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity)
        {
            
        }

        public void AssignId(ushort id)
        {
            _id = id;
        }
    }
}