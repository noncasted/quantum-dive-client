using System;
using Global.Network.Handlers.SceneCollectors.Abstract;
using Ragon.Client;

namespace Global.Network.Handlers.SceneCollectors.Runtime
{   
    public class SceneCollectorBridge : ISceneCollectorBridge
    {
        private INetworkSceneCollector _current;

        public void AddCollector(INetworkSceneCollector collector)
        {
            _current = collector;
        }
        
        public RagonEntity[] Collect()
        {
            if (_current == null)
                return Array.Empty<RagonEntity>();

            return _current.Collect();
        }
    }
}