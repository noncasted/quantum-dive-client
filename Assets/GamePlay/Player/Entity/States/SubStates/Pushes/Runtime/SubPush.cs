using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.Physics.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Runtime
{
    public class SubPush : ISubPush
    {
        public SubPush(IUpdater updater, IPlayerPhysics physics)
        {
            _updater = updater;
            _physics = physics;
        }
        
        private readonly IUpdater _updater;
        private readonly IPlayerPhysics _physics;
        
        public async UniTask PushAsync(
            Vector2 direction,
            PushParams parameters,
            CancellationToken cancellation)
        {
            var handler = new PushHandler(
                _updater,
                _physics,
                direction,
                parameters,
                cancellation);

            await handler.PushAsync();
        }
    }
}