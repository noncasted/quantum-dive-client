using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using GamePlay.Player.Entity.Components.Rotations.Orientation;

namespace GamePlay.Player.Entity.Components.Rotations.Animation
{
    public class LoopedRotatableAnimation : LoopedAnimation
    {
        public LoopedRotatableAnimation(
            RotatableFrameProvider frameProvider,
            AnimationData data) : 
            base(frameProvider, data)
        {
            _frameProvider = frameProvider;
        }
        
        private readonly RotatableFrameProvider _frameProvider;

        public IRotatableFrameProvider FrameProvider => _frameProvider;

        public void SetOrientation(PlayerOrientation orientation)
        {
            _frameProvider.SetOrientation(orientation);
        }
    }
}