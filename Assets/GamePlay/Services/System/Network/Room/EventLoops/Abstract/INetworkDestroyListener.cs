using Cysharp.Threading.Tasks;

namespace GamePlay.Services.System.Network.Room.EventLoops.Abstract
{
    public interface INetworkDestroyListener
    {
        UniTask OnNetworkDestroy();
    }
}