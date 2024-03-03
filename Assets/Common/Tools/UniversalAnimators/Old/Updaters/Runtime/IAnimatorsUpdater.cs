using Common.Architecture.Lifetimes;

namespace Common.Tools.UniversalAnimators.Updaters.Runtime
{
    public interface IAnimatorsUpdater
    {
        void Register(ILifetime lifetime, IUpdatableAnimator animator);
    }
}