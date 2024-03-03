using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common.Animations
{
    public class BowStrafeAnimation : AsyncAnimation
    {
        public BowStrafeAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}