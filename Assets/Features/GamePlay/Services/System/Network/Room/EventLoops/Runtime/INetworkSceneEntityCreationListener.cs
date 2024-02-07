using Cysharp.Threading.Tasks;
using GamePlay.System.Network.Room.Entities.Factory;

namespace GamePlay.System.Network.Room.EventLoops.Runtime
{
    public interface INetworkSceneEntityCreationListener
    {
        UniTask OnSceneEntityCreation(ISceneEntityFactory factory);
    }
}