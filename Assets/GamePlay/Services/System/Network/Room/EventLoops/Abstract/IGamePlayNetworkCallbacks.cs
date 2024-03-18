using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Callbacks;
using Ragon.Client;

namespace GamePlay.Services.System.Network.Room.EventLoops.Abstract
{
    public interface IGamePlayNetworkCallbacks
    {
        UniTask InvokeRegisterCallbacks(RagonEventCache events);
        UniTask InvokeSceneEntityCreation();
        UniTask InvokeAwakeCallbacks();
        UniTask InvokeDestroyCallbacks();
    }
}