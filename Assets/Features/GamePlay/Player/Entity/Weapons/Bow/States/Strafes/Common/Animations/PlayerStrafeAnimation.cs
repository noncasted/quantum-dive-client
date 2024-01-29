using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common.Animations
{
    public class PlayerStrafeAnimation : AsyncRotatableAnimation
    {
        public PlayerStrafeAnimation(
            RotatableFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}