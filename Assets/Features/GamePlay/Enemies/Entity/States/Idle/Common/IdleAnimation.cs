using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;

namespace GamePlay.Enemies.Entity.States.Idle.Common
{
    public class IdleAnimation : LoopedAnimation
    {
        public IdleAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}