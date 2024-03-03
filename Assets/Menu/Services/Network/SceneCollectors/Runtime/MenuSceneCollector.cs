using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Global.Network.Handlers.SceneCollectors.Runtime;
using Ragon.Client;

namespace Menu.Network.SceneCollectors.Runtime
{
    public class MenuSceneCollector : IMenuSceneCollector, IScopeAwakeListener
    {
        public MenuSceneCollector(ISceneCollectorBridge bridge)
        {
            _bridge = bridge;
        }
        
        private readonly ISceneCollectorBridge _bridge;

        private readonly List<RagonEntity> _entities = new();

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
            return _entities.ToArray();
        }

        public void Clear()
        {
            _entities.Clear();
        }
    }
}