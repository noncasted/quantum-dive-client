using Global.Network.Handlers.SceneCollectors.Abstract;

namespace GamePlay.Services.System.Network.Room.SceneCollectors.Abstract
{
    public interface IGameSceneCollector : INetworkSceneCollector
    {
        bool IsCollected { get; }
    }
}