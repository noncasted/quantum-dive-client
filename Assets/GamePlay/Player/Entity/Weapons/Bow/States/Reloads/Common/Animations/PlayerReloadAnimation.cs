using Common.Tools.UniversalAnimators.Animations.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Animation;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common.Animations
{
    public class PlayerReloadAnimation : AsyncRotatableAnimation
    {
        public PlayerReloadAnimation(
            RotatableFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}