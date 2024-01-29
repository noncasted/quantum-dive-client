using GamePlay.Enemies.Services.Updater.Runtime.Updatables;

namespace GamePlay.Enemies.Services.Updater.Runtime
{
    public interface IEnemyUpdater
    {
        void Add(IEnemyPathRecalculateUpdatable updatable);
        void Remove(IEnemyPathRecalculateUpdatable updatable);

        void Add(IEnemyTargetSearchUpdatable updatable);
        void Remove(IEnemyTargetSearchUpdatable updatable);
        
        void Add(IEnemyStateSelectionUpdatable updatable);
        void Remove(IEnemyStateSelectionUpdatable updatable);
    }
}