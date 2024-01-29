using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.States.Roll.Common
{       
    public class RollAnimation : AsyncRotatableAnimation
    {
        public RollAnimation(
            RotatableFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}       