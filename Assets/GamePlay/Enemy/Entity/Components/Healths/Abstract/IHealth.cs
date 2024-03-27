using Common.DataTypes.Runtime.Reactive;

namespace GamePlay.Enemy.Entity.Components.Healths.Abstract
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