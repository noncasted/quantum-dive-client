using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Callbacks;
using Ragon.Client;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    public interface IGamePlayNetworkCallbacks : ICallbacksRegistry
    {
        UniTask InvokeRegisterCallbacks(RagonEventCache events);
        UniTask InvokeSceneEntityCreation();
        UniTask InvokeAwakeCallbacks();
        UniTask InvokeDestroyCallbacks();
    }
}