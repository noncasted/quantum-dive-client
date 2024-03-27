using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Services.Network.Room.Entities.Factory
{
    public readonly struct AttachAwaiter
    {
        public AttachAwaiter(RagonEntity entity)
        {
            _entity = entity;
        }
        
        private readonly RagonEntity _entity;

        public async UniTask WaitAttachAsync()
        {
            if (_entity.IsAttached == true)
                return;
            
            var completion = new UniTaskCompletionSource();
            
            void OnAttached(RagonEntity entity)
            {
                completion.TrySetResult();
            }

            _entity.Attached += OnAttached;

            await completion.Task;
            
            _entity.Attached -= OnAttached;
        }
    }
}