using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Respawns.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RespawnRoutes.AnimationName, menuName = RespawnRoutes.AnimationPath)]
    public class RespawnAnimationFactory : AsyncAnimationFactory
    {
        public RespawnAnimation Create()
        {
            var frameProvider = new ForwardFrameProvider(Frames);
            var animation = new RespawnAnimation(frameProvider, Data);

            return animation;
        }
    }
}