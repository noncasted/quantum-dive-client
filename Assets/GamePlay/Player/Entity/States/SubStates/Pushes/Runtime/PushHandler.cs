﻿using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Player.Entity.Views.Physics.Abstract;
using Global.System.Updaters.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Runtime
{
    public class PushHandler : IUpdatable
    {
        public PushHandler(
            IUpdater updater,
            IPlayerPhysics physics,
            Vector2 direction,
            PushParams parameters,
            CancellationToken cancellation)
        {
            _updater = updater;
            _physics = physics;
            _direction = direction;
            _params = parameters;
            _cancellation = cancellation;
            _completion = new UniTaskCompletionSource();

            _time = 0f;
            _previousEvaluation = 0f;
        }
        
        private readonly IUpdater _updater;
        private readonly IPlayerPhysics _physics;

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
            
            _physics.Move(_direction, distance);

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