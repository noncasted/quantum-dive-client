using Common.Tools.ObjectsPools.Runtime;

namespace GamePlay.Projectiles.Registry.Definition
{
    public interface IProjectileDefinition
    {
        IPoolEntry PoolEntry { get; }
    }
}