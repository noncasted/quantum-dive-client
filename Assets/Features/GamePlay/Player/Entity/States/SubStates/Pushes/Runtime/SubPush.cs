using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.RigidBodies.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Runtime
{
    public class SubPush : ISubPush
    {
        public SubPush(IUpdater updater, IPlayerRigidBody rigidBody)
        {
            _updater = updater;
            _rigidBody = rigidBody;
        }
        
        private readonly IUpdater _updater;
        private readonly IPlayerRigidBody _rigidBody;
        
        public async UniTask PushAsync(
            Vector2 direction,
            PushParams parameters,
            CancellationToken cancellation)
        {
            var handler = new PushHandler(
                _updater,
                _rigidBody,
                direction,
                parameters,
                cancellation);

            await handler.PushAsync();
        }
    }
}