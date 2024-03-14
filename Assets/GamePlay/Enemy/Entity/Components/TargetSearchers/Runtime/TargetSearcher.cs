
using Internal.Scopes.Abstract.Lifetimes;
using GamePlay.Combat.Targets.Registry.Runtime;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Debug.Gizmos;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Enemy.Updater.Runtime;
using GamePlay.Enemy.Updater.Runtime.Updatables;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime
{
    public class TargetSearcher :
        ITargetSearcher,
        IEnemyTargetSearchUpdatable,
        ITargetProvider,
        IEntitySwitchLifetimeListener
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
        }

        private readonly ITargetPlayerRegistry _targetRegistry;
        private readonly IEnemyUpdater _updater;
        private readonly IEnemyPosition _position;
        private readonly ISearchConfig _config;
        private readonly ISearchGizmos _gizmos;

        private ISearchableTarget _current;
        
        public ISearchableTarget Current => _current;
        public bool IsTargetReached => CheckTargetReached();

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
        }
        
        private bool CheckTargetReached()
        {
            if (_current == null)
                return false;

            var distance = Vector2.Distance(_position.Position, _current.Position);

            if (distance > _config.StopDistance)
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
            
            _current = nearest;
        }
    }
}