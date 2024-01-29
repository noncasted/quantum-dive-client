using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Lifecycle.Runtime;
using Ragon.Client;

namespace GamePlay.Player.Entity.Setup.Bootstrap.Local
{
    public class PlayerAttachHandler
    {
        public PlayerAttachHandler(IRoomLifecycle lifecycle, RagonEntity entity, IRagonPayload payload)
        {
            _lifecycle = lifecycle;
            Entity = entity;
            _payload = payload;
        }

        private readonly IRoomLifecycle _lifecycle;
        public readonly RagonEntity Entity;
        private readonly IRoomProvider _roomProvider;
        private readonly IRagonPayload _payload;

        public async UniTask SendToNetwork()
        {
            var completion = new UniTaskCompletionSource();

            void OnAttached(RagonEntity entity)
            {
                completion.TrySetResult();
            }

            Entity.Attached += OnAttached;
            
            _lifecycle.SendEntity(Entity, _payload);
            
            await completion.Task;
            
            Entity.Attached -= OnAttached;
        }
    }
}