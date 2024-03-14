using Common.Tools.UniversalAnimators.Old.Animations.Abstract;
using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Looped;

namespace GamePlay.Enemy.Entity.States.Following.Common
{
    public class FollowingAnimation : LoopedAnimation
    {
        public FollowingAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}