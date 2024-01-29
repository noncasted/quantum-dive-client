using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.States.Runs.Common
{
    public class RunAnimation : LoopedRotatableAnimation
    {
        public RunAnimation(RotatableFrameProvider frameProvider, AnimationData data) : base(frameProvider, data)
        {
        }
    }
}