using GamePlay.Player.Entity.Components.Rotations.Orientation;

namespace GamePlay.Player.Entity.Components.Rotations.Animation
{
    public interface IRotatableFrameProvider
    {
        public void SetOrientation(PlayerOrientation orientation);
    }
}