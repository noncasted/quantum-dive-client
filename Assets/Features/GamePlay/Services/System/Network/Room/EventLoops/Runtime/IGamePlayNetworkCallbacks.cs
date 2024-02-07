using Common.Architecture.Container.Abstract;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.System.Network.Room.EventLoops.Runtime
{
    public interface IGamePlayNetworkCallbacks : ICallbackRegistry
    {
        UniTask InvokeRegisterCallbacks(RagonEventCache events);
        UniTask InvokeSceneEntityCreation();
        UniTask InvokeAwakeCallbacks();
        UniTask InvokeDestroyCallbacks();
    }
}