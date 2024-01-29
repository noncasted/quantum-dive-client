using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.States.Idles.Common
{
    public class IdleAnimation : LoopedRotatableAnimation
    {
        public IdleAnimation(
            RotatableFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}