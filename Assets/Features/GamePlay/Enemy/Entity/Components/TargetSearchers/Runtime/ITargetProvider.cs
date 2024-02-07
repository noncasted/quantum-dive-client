using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime
{
    public interface ITargetProvider
    {
        ISearchableTarget Current { get; }
        bool IsTargetReached { get; }
    }
}