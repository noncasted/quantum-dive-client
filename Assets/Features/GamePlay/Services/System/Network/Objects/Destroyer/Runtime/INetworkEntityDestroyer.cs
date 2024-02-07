using GamePlay.System.Network.Objects.Definition;

namespace GamePlay.System.Network.Objects.Destroyer.Runtime
{
    public interface INetworkEntityDestroyer
    {
        void Destroy(INetworkObject networkObject);
    }
}