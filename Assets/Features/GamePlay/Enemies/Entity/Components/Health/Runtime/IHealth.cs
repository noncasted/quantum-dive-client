using System;

namespace GamePlay.Enemies.Entity.Components.Health.Runtime
{
    public interface IHealth
    {
        event Action<int, int> HealthChanged;

        int Amount { get; }
        bool IsAlive { get; }

        void Remove(int amount);
        void Restore();
    }
}