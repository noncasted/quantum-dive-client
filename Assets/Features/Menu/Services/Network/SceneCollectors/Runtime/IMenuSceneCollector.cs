using Global.Network.Handlers.SceneCollectors.Runtime;

namespace Menu.Services.Network.SceneCollectors.Runtime
{
    public interface IMenuSceneCollector : INetworkSceneCollector
    {
        void Clear();
    }
}