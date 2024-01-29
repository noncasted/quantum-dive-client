using Global.Network.Handlers.SceneCollectors.Runtime;

namespace Menu.Network.SceneCollectors.Runtime
{
    public interface IMenuSceneCollector : INetworkSceneCollector
    {
        void Clear();
    }
}