using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;

namespace GamePlay.Player.Entity.Setup.Root.Remote
{
    public class RemotePlayerRoot : IRemotePlayerRoot
    {
        public RemotePlayerRoot(IPlayerObjectEventLoop objectEventLoop)
        {
            _objectEventLoop = objectEventLoop;
        }
        
        private readonly IPlayerObjectEventLoop _objectEventLoop;

        public async UniTask OnBootstrapped()
        {
            _objectEventLoop.InvokeAwake();
            await _objectEventLoop.InvokeAsyncAwake();
            _objectEventLoop.InvokeEnable();
            _objectEventLoop.InvokeStart();      
        }

        public void OnEntityAttached()
        {
            _objectEventLoop.InvokeEntityAttached();
        }
    }
}