using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common.Animations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ReloadRoutes.BowAnimationName, menuName = ReloadRoutes.BowAnimationPath)]
    public class BowReloadAnimationFactory : AsyncAnimationFactory
    {
        public BowReloadAnimation Create()
        {
            var frameProvider = new ForwardFrameProvider(Frames);
            var animation = new BowReloadAnimation(frameProvider, Data);

            return animation;
        }
    }
}