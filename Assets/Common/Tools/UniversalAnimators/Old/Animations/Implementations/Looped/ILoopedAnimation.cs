using Common.Tools.UniversalAnimators.Old.Animations.Abstract;

namespace Common.Tools.UniversalAnimators.Old.Animations.Implementations.Looped
{
    public interface ILoopedAnimation : IUpdatableAnimation
    {
        AnimationData Data { get; }
        void Play();
    }
}