using System.Collections.Generic;
using GamePlay.Services.System.Network.Room.SceneCollectors.Abstract;
using Global.Network.Handlers.SceneCollectors.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Ragon.Client;

namespace GamePlay.Services.Network.Room.SceneCollectors.Runtime
{
    public class NetworkSceneCollector : IGameSceneCollector, IScopeAwakeListener
    {
        public NetworkSceneCollector(ISceneCollectorBridge bridge)
        {
            _bridge = bridge;
        }

        private readonly ISceneCollectorBridge _bridge;
        private readonly List<RagonEntity> _entities = new();

        private bool _isCollected;

        public bool IsCollected => _isCollected;

        public RagonEntity[] Entities => _entities.ToArray();
        
        public void OnAwake()
        {
            _bridge.AddCollector(this);
        }
        
        public void AddEntity(RagonEntity entity)
        {
            _entities.Add(entity);
        }

        public RagonEntity[] Collect()
        {
            _isCollected = true;
            return _entities.ToArray();
        }
    }
}