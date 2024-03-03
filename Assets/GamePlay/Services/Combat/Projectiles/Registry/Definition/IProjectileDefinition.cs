using Common.Tools.ObjectsPools.Runtime;

namespace GamePlay.Combat.Projectiles.Registry.Definition
{
    public interface IProjectileDefinition
    {
        IPoolEntry PoolEntry { get; }
    }
}