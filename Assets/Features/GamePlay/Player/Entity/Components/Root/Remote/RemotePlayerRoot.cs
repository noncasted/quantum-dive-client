using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Common.Definition;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Runtime;

namespace GamePlay.Player.Entity.Components.Root.Remote
{
    public class RemotePlayerRoot : IRemotePlayerRoot
    {
        public RemotePlayerRoot(
            IPlayerPosition position,
            IPlayerTransform transform,
            IHealth health,
            IEntityCallbacks callbacks)
        {
            _position = position;
            _transform = transform;
            _health = health;
            _callbacks = callbacks;
        }

        private readonly IPlayerPosition _position;
        private readonly IPlayerTransform _transform;
        private readonly IHealth _health;
        private readonly IEntityCallbacks _callbacks;

        private ILifetime _lifetime;

        public IEntityCallbacks Callbacks => _callbacks;
        public IHealth Health => _health;
        public IPlayerPosition Position => _position;
        public IPlayerTransform Transform => _transform;

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