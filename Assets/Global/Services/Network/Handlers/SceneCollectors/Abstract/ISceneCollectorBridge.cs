using Ragon.Client;

namespace Global.Network.Handlers.SceneCollectors.Abstract
{
    public interface ISceneCollectorBridge : IRagonSceneCollector
    {
        void AddCollector(INetworkSceneCollector collector);
    }
}