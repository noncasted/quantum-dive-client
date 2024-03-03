using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations
{
    public class PlayerAimAnimation : AsyncRotatableAnimation
    {
        public PlayerAimAnimation(RotatableFrameProvider frameProvider, AnimationData data) : base(frameProvider, data)
        {
        }
    }
}