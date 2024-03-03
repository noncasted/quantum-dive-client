using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common.Animations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.BowAnimationName,
        menuName = BowStrafeRoutes.BowAnimationPath)]
    public class BowStrafeAnimationFactory : AsyncAnimationFactory
    {
        public BowStrafeAnimation Create()
        {
            var frameProvider = new ForwardFrameProvider(Frames);
            var animation = new BowStrafeAnimation(frameProvider, Data);

            return animation;
        }
    }
}