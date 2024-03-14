using Ragon.Client;

namespace GamePlay.Services.System.Network.Room.Lifecycle.Abstract
{
    public interface IRoomLifecycle
    {
        void SceneLoaded();
        void SendEntity(RagonEntity entity, IRagonPayload payload = null);
    }
}