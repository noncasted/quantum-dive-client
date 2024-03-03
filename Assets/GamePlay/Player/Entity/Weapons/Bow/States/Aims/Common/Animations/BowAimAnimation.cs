using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations
{
    public class BowAimAnimation : AsyncAnimation
    {
        public BowAimAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}