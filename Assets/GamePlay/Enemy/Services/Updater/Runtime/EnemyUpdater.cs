using GamePlay.Enemy.Updater.Runtime.Updatables;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Enemy.Updater.Runtime
{
    public class EnemyUpdater : IEnemyUpdater, IPreFixedUpdatable, IScopeLifetimeListener
    {
        public EnemyUpdater(IUpdater updater, IRatesConfig ratesConfig)
        {
            _updater = updater;

            _pathRecalculationTimer = new UpdaterTimer(ratesConfig.PathRecalculateRate);
            _targetSearchTimer = new UpdaterTimer(ratesConfig.TargetSearchRate);
            _stateSelectionTimer = new UpdaterTimer(ratesConfig.StateSelectionRate);
        }

        private readonly IUpdater _updater;

        private readonly UpdatablesHandler<IEnemyPathRecalculateUpdatable> _pathRecalculations = new();
        private readonly UpdatablesHandler<IEnemyTargetSearchUpdatable> _targetSearchers = new();
        private readonly UpdatablesHandler<IEnemyStateSelectionUpdatable> _stateSelectors = new();

        private readonly UpdaterTimer _pathRecalculationTimer;
        private readonly UpdaterTimer _targetSearchTimer;
        private readonly UpdaterTimer _stateSelectionTimer;

        public void Add(ILifetime lifetime, IEnemyPathRecalculateUpdatable updatable)
        {
            _pathRecalculations.Add(updatable);
            lifetime.ListenTerminate(() => _pathRecalculations.Remove(updatable));
        }

        public void Add(ILifetime lifetime, IEnemyTargetSearchUpdatable updatable)
        {
            _targetSearchers.Add(updatable);
            lifetime.ListenTerminate(() => _targetSearchers.Remove(updatable));
        }

        public void Add(ILifetime lifetime, IEnemyStateSelectionUpdatable updatable)
        {
            _stateSelectors.Add(updatable);
            lifetime.ListenTerminate(() => _stateSelectors.Remove(updatable));
        }

        public void OnLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
        }

        public void OnPreFixedUpdate(float delta)
        {
            _pathRecalculations.Fetch();
            _targetSearchers.Fetch();
            _stateSelectors.Fetch();

            if (_pathRecalculationTimer.IsAvailable(delta) == true)
            {
                foreach (var updatable in _pathRecalculations.List)
                    updatable.OnPathRecalculation();
            }

            if (_targetSearchTimer.IsAvailable(delta) == true)
            {
                foreach (var updatable in _targetSearchers.List)
                    updatable.OnTargetSearch();
            }

            if (_stateSelectionTimer.IsAvailable(delta) == true)
            {
                foreach (var updatable in _stateSelectors.List)
                    updatable.OnStateSelect();
            }
        }
    }
}