using Global.Network.Handlers.SceneCollectors.Abstract;

namespace Menu.Services.Network.SceneCollectors.Runtime
{
    public interface IMenuSceneCollector : INetworkSceneCollector
    {
        void Clear();
    }
}