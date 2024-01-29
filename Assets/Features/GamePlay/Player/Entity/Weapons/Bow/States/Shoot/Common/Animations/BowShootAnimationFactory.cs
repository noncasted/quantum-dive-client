using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.BowAnimationName, menuName = ShootRoutes.BowAnimationPath)]
    public class BowShootAnimationFactory : AsyncAnimationFactory
    {
        public BowShootAnimation Create()
        {
            var frameProvider = new ForwardFrameProvider(Frames);
            var animation = new BowShootAnimation(frameProvider, Data);

            return animation;
        }
    }
}