using Common.DataTypes.Reactive;

namespace GamePlay.Enemy.Entity.Components.Health.Abstract
{
    public interface IHealth
    {
        IViewableDelegate<int, int> HealthChanged { get; }

        int Amount { get; }
        bool IsAlive { get; }

        void Remove(int amount);
        void Restore();
    }
}