using Cysharp.Threading.Tasks;

namespace GamePlay.Player.Entity.Setup.EventLoop.Abstract
{
    public interface IPlayerObjectEventLoop
    {
        void InvokeEntityAttached();

        void InvokeAwake();
        UniTask InvokeAsyncAwake();
        void InvokeStart();
        void InvokeEnable();
        void InvokeDisable();
        void InvokeDestroy();
    }
}