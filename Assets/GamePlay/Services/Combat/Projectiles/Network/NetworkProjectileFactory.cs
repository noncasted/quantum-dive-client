using Cysharp.Threading.Tasks;
using GamePlay.Combat.Projectiles.Factory;
using GamePlay.Combat.Projectiles.Registry.Runtime;
using GamePlay.System.Network.Room.Entities.Factory;
using GamePlay.System.Network.Room.EventLoops.Runtime;
using Internal.Scopes.Abstract.Instances.Services;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Combat.Projectiles.Network
{
    public class NetworkProjectileFactory : INetworkSceneEntityCreationListener, IScopeSwitchListener
    {
        public NetworkProjectileFactory(
            ISceneEntityFactory entityFactory,
            IProjectileFactory factory,
            IProjectileDefinitionsRegistry definitionsRegistry)
        {
            _factory = factory;
            _definitionsRegistry = definitionsRegistry;

            _entity = entityFactory.CreateLocal();
        }

        private readonly RagonEntity _entity;
        
        private readonly IProjectileFactory _factory;
        private readonly IProjectileDefinitionsRegistry _definitionsRegistry;
        
        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            await factory.AttachAsync(_entity);
            
            _entity.OnEvent<PlayerProjectileRequestEvent>(OnRemotePlayerProjectileCreated);
            _entity.OnEvent<EnemyProjectileRequestEvent>(OnRemoteEnemyProjectileCreated);
        }
        
        public void OnEnabled()
        {
            _factory.PlayerProjectileCreated += OnLocalPlayerProjectileCreated;
            _factory.EnemyProjectileCreated += OnLocalEnemyProjectileCreated;
        }
        
        public void OnDisabled()
        {
            _factory.PlayerProjectileCreated -= OnLocalPlayerProjectileCreated;
            _factory.EnemyProjectileCreated -= OnLocalEnemyProjectileCreated;
        }

        private void OnLocalPlayerProjectileCreated(ProjectileRequest request)
        {
            var projectileId = _definitionsRegistry.GetId(request.Definition);
            
            var networkRequest = new PlayerProjectileRequestEvent(
                projectileId,
                request.Position,
                request.Direction,
                request.Parameters);

            _entity.ReplicateEvent(networkRequest, RagonTarget.ExceptInvoker);
        }
        
        private void OnLocalEnemyProjectileCreated(ProjectileRequest request)
        {
            var projectileId = _definitionsRegistry.GetId(request.Definition);
            
            var networkRequest = new EnemyProjectileRequestEvent(
                projectileId,
                request.Position,
                request.Direction,
                request.Parameters);
            
            _entity.ReplicateEvent(networkRequest, RagonTarget.ExceptInvoker);
        }

        private void OnRemotePlayerProjectileCreated(RagonPlayer player, PlayerProjectileRequestEvent networkRequest)
        {
            var definition = _definitionsRegistry.GetDefinition(networkRequest.DefinitionId);
            
            var shootParams = new ShootParams(
                0,
                0f,
                networkRequest.Speed,
                networkRequest.Scale,
                networkRequest.Radius);

            var localRequest = new ProjectileRequest(
                definition,
                networkRequest.Position,
                networkRequest.Direction,
                shootParams);

            _factory.CreateRemotePlayer(localRequest);
        }
        
        private void OnRemoteEnemyProjectileCreated(RagonPlayer player, EnemyProjectileRequestEvent networkRequest)
        {
            var definition = _definitionsRegistry.GetDefinition(networkRequest.DefinitionId);
            
            var shootParams = new ShootParams(
                networkRequest.Damage,
                networkRequest.PushForce,
                networkRequest.Speed,
                networkRequest.Scale,
                networkRequest.Radius);

            var localRequest = new ProjectileRequest(
                definition,
                networkRequest.Position,
                networkRequest.Direction,
                shootParams);

            _factory.CreateRemoteEnemy(localRequest);
        }
    }
}