using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Enemy.Spawn.Factory.Runtime
{
    public class RemoteAttachAwaiter
    {
        public RemoteAttachAwaiter(RagonEntity entity)
        {
            Entity = entity;
        }
        
        public readonly RagonEntity Entity;
        private readonly IRagonPayload _payload;

        public async UniTask AwaitAttach()
        {
            var completion = new UniTaskCompletionSource();

            void OnAttached(RagonEntity entity)
            {
                completion.TrySetResult();
            }

            Entity.Attached += OnAttached;
            
            await completion.Task;
            
            Entity.Attached -= OnAttached;
        }
    }
}