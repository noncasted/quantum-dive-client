using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime
{
    public interface ITargetProvider
    {
        ISearchableTarget Current { get; }
        bool IsTargetReached { get; }
    }
}