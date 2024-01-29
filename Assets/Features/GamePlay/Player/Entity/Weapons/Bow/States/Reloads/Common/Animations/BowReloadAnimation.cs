using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common.Animations
{
    public class BowReloadAnimation : AsyncAnimation
    {
        public BowReloadAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}