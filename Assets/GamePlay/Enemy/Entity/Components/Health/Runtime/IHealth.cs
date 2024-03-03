using Common.Architecture.Lifetimes.Viewables;

namespace GamePlay.Enemy.Entity.Components.Health.Runtime
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