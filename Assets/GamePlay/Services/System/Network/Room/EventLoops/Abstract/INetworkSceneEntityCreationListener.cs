using Cysharp.Threading.Tasks;
using GamePlay.Services.Network.Room.Entities.Factory;

namespace GamePlay.Services.System.Network.Room.EventLoops.Abstract
{
    public interface INetworkSceneEntityCreationListener
    {
        UniTask OnSceneEntityCreation(ISceneEntityFactory factory);
    }
}