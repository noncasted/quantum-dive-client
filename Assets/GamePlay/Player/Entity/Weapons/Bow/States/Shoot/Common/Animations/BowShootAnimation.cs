using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations
{
    public class BowShootAnimation : AsyncAnimation
    {
        public BowShootAnimation(
            ForwardFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}