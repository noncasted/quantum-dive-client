using Cysharp.Threading.Tasks;

namespace GamePlay.Player.Entity.Setup.EventLoop.Abstract
{
    public interface IPlayerAsyncAwakeListener
    {
        UniTask OnAsyncAwake();
    }
}