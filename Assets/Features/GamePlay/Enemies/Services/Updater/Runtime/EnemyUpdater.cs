using Common.Architecture.Scopes.Runtime.Callbacks;
using GamePlay.Enemies.Services.Updater.Runtime.Updatables;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Enemies.Services.Updater.Runtime
{
    public class EnemyUpdater : IEnemyUpdater, IPreFixedUpdatable, IScopeSwitchListener
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
        
        public void OnEnabled()
        {
            _updater.Add(this);
        }
        
        public void OnDisabled()
        {
            _updater.Remove(this);
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
        
        public void Add(IEnemyPathRecalculateUpdatable updatable)
        {
            _pathRecalculations.Add(updatable);
        }

        public void Add(IEnemyTargetSearchUpdatable updatable)
        {
            _targetSearchers.Add(updatable);
        }

        public void Remove(IEnemyPathRecalculateUpdatable updatable)
        {
            _pathRecalculations.Remove(updatable);
        }

        public void Remove(IEnemyTargetSearchUpdatable updatable)
        {
            _targetSearchers.Remove(updatable);
        }

        public void Add(IEnemyStateSelectionUpdatable updatable)
        {
            _stateSelectors.Add(updatable);
        }

        public void Remove(IEnemyStateSelectionUpdatable updatable)
        {
            _stateSelectors.Remove(updatable);
        }
    }
}