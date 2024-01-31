using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;

namespace GamePlay.Player.Entity.Setup.Root.Remote
{
    public class RemotePlayerRoot : IRemotePlayerRoot
    {
        public RemotePlayerRoot(IEntityCallbacks callbacks)
        {
            _callbacks = callbacks;
        }
        
        private readonly IEntityCallbacks _callbacks;

        private ILifetime _lifetime;

        public IEntityCallbacks Callbacks => _callbacks;

        public async UniTask Enable()
        {
            if (_lifetime != null)
                await _lifetime.Terminate();

            _lifetime = new Lifetime();

            await _callbacks.RunEnable(_lifetime);
        }

        public async UniTask Disable()
        {
            await _lifetime.Terminate();

            _lifetime = new Lifetime();

            await _callbacks.RunEnable(_lifetime);
        }
    }
}