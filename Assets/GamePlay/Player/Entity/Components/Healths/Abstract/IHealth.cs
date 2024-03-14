
namespace GamePlay.Player.Entity.Components.Healths.Runtime
{
    public interface IHealth
    {
        void Construct(int max);
        bool IsAlive { get; }

        void Heal(int heal);

        void AddMax(int add);
        void ReduceMax(int reduce);

        void OnDamage(int damage);
    }
}