using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Lifecycle.Runtime;
using Ragon.Client;

namespace GamePlay.Enemy.Spawn.Factory.Runtime
{
    public class LocalAttachAwaiter
    {
        public LocalAttachAwaiter(IRoomLifecycle roomProvider, RagonEntity entity, IRagonPayload payload)
        {
            _entity = entity;
            _payload = payload;
            _roomProvider = roomProvider;
        }
        
        private readonly RagonEntity _entity;
        private readonly IRoomLifecycle _roomProvider;
        private readonly IRagonPayload _payload;

        public async UniTask SendToNetwork()
        {
            var completion = new UniTaskCompletionSource();

            void OnAttached(RagonEntity entity)
            {
                completion.TrySetResult();
            }

            _entity.Attached += OnAttached;
            
            _roomProvider.SendEntity(_entity, _payload);
            
            await completion.Task;
            
            _entity.Attached -= OnAttached;
        }
    }
}