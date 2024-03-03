using Cysharp.Threading.Tasks;

namespace GamePlay.System.Network.Room.EventLoops.Runtime
{
    public interface INetworkDestroyListener
    {
        UniTask OnNetworkDestroy();
    }
}