using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.RigidBodies.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Runtime
{
    public class PushHandler : IUpdatable
    {
        public PushHandler(
            IUpdater updater,
            IPlayerRigidBody rigidBody,
            Vector2 direction,
            PushParams parameters,
            CancellationToken cancellation)
        {
            _updater = updater;
            _rigidBody = rigidBody;
            _direction = direction;
            _params = parameters;
            _cancellation = cancellation;
            _completion = new UniTaskCompletionSource();

            _time = 0f;
            _previousEvaluation = 0f;
        }
        
        private readonly IUpdater _updater;
        private readonly IPlayerRigidBody _rigidBody;

        private readonly Vector2 _direction;
        private readonly PushParams _params;
        private readonly CancellationToken _cancellation;

        private readonly UniTaskCompletionSource _completion;
        
        private float _time;
        private float _previousEvaluation;

        public async UniTask PushAsync()
        {
            _updater.Add(this);

            _cancellation.Register(OnCanceled);

            await _completion.Task;

            _updater.Remove(this);
        }
        
        public void OnUpdate(float delta)
        {
            if (_time >= _params.Time)
            {
                _completion.TrySetResult();
                return;
            }

            var evaluation = _params.Curve.Evaluate(_time / _params.Time);
            var difference = evaluation - _previousEvaluation;
            var distance = difference * _params.Distance;
            
            _rigidBody.Move(_direction, distance);

            _time += delta;
            _previousEvaluation = evaluation;
        }

        private void OnCanceled()
        {
            _completion.TrySetCanceled();
            _updater.Remove(this);
        }
    }
}