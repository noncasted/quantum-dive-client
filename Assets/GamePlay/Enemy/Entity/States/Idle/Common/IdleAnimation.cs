using Common.Tools.UniversalAnimators.Old.Animations.Abstract;
using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Looped;

namespace GamePlay.Enemy.Entity.States.Idle.Common
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