using GamePlay.Services.Network.Objects.Definition;

namespace GamePlay.Services.System.Network.Objects.Destroyer.Abstract
{
    public interface INetworkEntityDestroyer
    {
        void Destroy(INetworkObject networkObject);
    }
}