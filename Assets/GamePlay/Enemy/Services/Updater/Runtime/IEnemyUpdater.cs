using GamePlay.Enemy.Updater.Runtime.Updatables;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Enemy.Updater.Runtime
{
    public interface IEnemyUpdater
    {
        void Add(ILifetime lifetime, IEnemyPathRecalculateUpdatable updatable);
        void Add(ILifetime lifetime, IEnemyTargetSearchUpdatable updatable);
        void Add(ILifetime lifetime, IEnemyStateSelectionUpdatable updatable);
    }
}