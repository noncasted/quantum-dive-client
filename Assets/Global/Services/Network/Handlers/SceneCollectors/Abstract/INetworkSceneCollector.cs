using Ragon.Client;

namespace Global.Network.Handlers.SceneCollectors.Abstract
{
    public interface INetworkSceneCollector
    {
        void AddEntity(RagonEntity entity);
        RagonEntity[] Collect();
    }
}