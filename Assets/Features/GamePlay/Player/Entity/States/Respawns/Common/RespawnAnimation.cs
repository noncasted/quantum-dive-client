using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Player.Entity.States.Respawns.Common
{
    public class RespawnAnimation : AsyncAnimation
    {
        public RespawnAnimation(IFrameProvider frameProvider, AnimationData data) : base(frameProvider, data)
        {
        }
    }
}