using Global.Network.Handlers.SceneCollectors.Abstract;

namespace GamePlay.Network.Room.SceneCollectors.Runtime
{
    public interface IGameSceneCollector : INetworkSceneCollector
    {
        bool IsCollected { get; }
    }
}