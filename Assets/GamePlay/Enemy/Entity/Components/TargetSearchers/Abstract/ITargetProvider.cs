using GamePlay.Services.Combat.Targets.Registry.Abstract;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Abstract
{
    public interface ITargetProvider
    {
        ISearchableTarget Current { get; }
        bool IsTargetReached { get; }
    }
}