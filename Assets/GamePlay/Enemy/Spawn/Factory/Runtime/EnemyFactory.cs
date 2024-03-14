using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using GamePlay.Enemy.Services.Mappers.Definitions.Abstract;
using GamePlay.Enemy.Spawn.Factory.Abstract;
using GamePlay.Enemy.Spawn.Factory.Logs;
using GamePlay.Enemy.Spawn.Pool.Abstract;
using GamePlay.Enemy.Spawn.Pool.Runtime;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Services.System.Network.Objects.Factories.Abstract;
using Global.Network.Objects.Factories.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Factory.Runtime
{
    public class EnemyFactory : IEnemyFactory, IEntityFactory, IScopeLifetimeListener
    {
        public EnemyFactory(
            INetworkFactoriesRegistry factoriesRegistry,
            IDynamicEntityFactory dynamicEntityFactory,
            IEnemyPool pool,
            IEnemyDefinitionMapper definitionMapper,
            EnemyFactoryLogger logger)
        {
            _factoriesRegistry = factoriesRegistry;
            _dynamicEntityFactory = dynamicEntityFactory;
            _pool = pool;
            _definitionMapper = definitionMapper;
            _logger = logger;
        }

        private readonly INetworkFactoriesRegistry _factoriesRegistry;
        private readonly IDynamicEntityFactory _dynamicEntityFactory;
        private readonly IEnemyPool _pool;
        private readonly IEnemyDefinitionMapper _definitionMapper;
        private readonly EnemyFactoryLogger _logger;

        private readonly ObjectIdGenerator _typeGenerator = new();

        private ushort _id;

        public ushort Id => _id;

        public void OnLifetimeCreated(ILifetime lifetime)
        {
            _id = _factoriesRegistry.Register(this, lifetime);
        }

        public async UniTask CreateAsync(IEnemyDefinition definition, Vector2 position)
        {
            var type = _typeGenerator.Generate(_id, definition.Identification.Id);
            var entity = _dynamicEntityFactory.Create(type);
            var root = await _pool.GetLocal(definition, position, entity);
            var payload = new EnemySpawnPayload(position);
            await _dynamicEntityFactory.Send(entity, payload);

            _logger.OnLocal(definition.Identification.Name, position);
        }

        public async UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity)
        {
            var prefabId = _typeGenerator.GetPrefabId(objectId);
            var definition = _definitionMapper.GetDefinition(prefabId.ObjectId);
            var root = await _pool.GetRemote(definition, entity);
            _logger.OnRemote(definition.Identification.Name, entity.GetAttachPayload<EnemySpawnPayload>().Position);
        }
    }
}