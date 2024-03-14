using Common.Tools.UniversalAnimators.Old.Animations.Abstract;
using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Async;

namespace GamePlay.Enemy.Entity.States.Death.Common
{
    public class DeathAnimation : AsyncAnimation
    {
        public DeathAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}