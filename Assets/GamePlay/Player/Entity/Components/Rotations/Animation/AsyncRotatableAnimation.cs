using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using GamePlay.Player.Entity.Components.Rotations.Orientation;

namespace GamePlay.Player.Entity.Components.Rotations.Animation
{
    public class AsyncRotatableAnimation : AsyncAnimation
    {
        public AsyncRotatableAnimation(
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