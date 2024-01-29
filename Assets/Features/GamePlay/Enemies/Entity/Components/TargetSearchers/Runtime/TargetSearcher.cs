using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Debug.Gizmos;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Enemies.Services.Updater.Runtime;
using GamePlay.Enemies.Services.Updater.Runtime.Updatables;
using GamePlay.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime
{
    public class TargetSearcher :
        ITargetSearcher,
        IEnemyTargetSearchUpdatable,
        ITargetProvider,
        IEnemySwitchListener
    {
        public TargetSearcher(
            ITargetPlayerRegistry targetRegistry,
            IEnemyUpdater updater,
            IEnemyPosition position,
            ISearchConfig config,
            ISearchGizmos gizmos)
        {
            _targetRegistry = targetRegistry;
            _updater = updater;
            _position = position;
            _config = config;
            _gizmos = gizmos;

            _cancel = OnCanceled;
        }

        private readonly ITargetPlayerRegistry _targetRegistry;
        private readonly IEnemyUpdater _updater;
        private readonly IEnemyPosition _position;
        private readonly ISearchConfig _config;
        private readonly ISearchGizmos _gizmos;

        private readonly Action _cancel;

        private UniTaskCompletionSource<ISearchableTarget> _completion;
        private ISearchableTarget _current;
        
        public ISearchableTarget Current => _current;
        public bool IsTargetReached => CheckTargetReached();

        private bool CheckTargetReached()
        {
            if (_current == null)
                return false;

            var distance = Vector2.Distance(_position.Position, _current.Position);

            if (distance > _config.StopDistance)
                return false;

            return true;
        }

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }
        
        public async UniTask<ISearchableTarget> SearchAsync(CancellationToken cancellation)
        {
            cancellation.Register(_cancel);

            _completion = new UniTaskCompletionSource<ISearchableTarget>();

            var nearest = await _completion.Task;

            return nearest;
        }

        public bool IsTargetInSearchRange(ISearchableTarget target)
        {
            var distance = Vector2.Distance(_position.Position, target.Position);

            if (distance > _config.Radius)
                return false;

            return true;
        }

        public void OnTargetSearch()
        {
            var origin = _position.Position;

            if (_targetRegistry.TryGetNearest(origin, out var nearest) == false)
            {
                _gizmos.DrawFailArea(origin, _config.Radius);
                _current = null;
                return;
            }

            var distance = Vector2.Distance(origin, nearest.Position);

            if (distance > _config.Radius)
            {
                _gizmos.DrawFailArea(origin, _config.Radius);
                _current = null;
                return;
            }

            _gizmos.DrawSuccessArea(origin, _config.Radius);
            _gizmos.DrawSuccessLine(origin, nearest.Position);
            
            _completion?.TrySetResult(nearest);
            _current = nearest;
        }

        private void OnCanceled()
        {
            _updater.Remove(this);
        }
    }
}