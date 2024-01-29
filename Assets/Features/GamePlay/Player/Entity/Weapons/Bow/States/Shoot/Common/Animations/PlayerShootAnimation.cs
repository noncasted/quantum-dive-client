using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations
{
    public class PlayerShootAnimation : AsyncRotatableAnimation
    {
        public PlayerShootAnimation(
            RotatableFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}