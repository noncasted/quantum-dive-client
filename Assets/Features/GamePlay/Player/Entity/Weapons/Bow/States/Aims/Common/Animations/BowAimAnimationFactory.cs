using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowAimRoutes.BowAnimationName, menuName = BowAimRoutes.BowAnimationPath)]
    public class BowAimAnimationFactory : AsyncAnimationFactory
    {
        public BowAimAnimation Create()
        {
            var frameProvider = new ForwardFrameProvider(Frames);
            var animation = new BowAimAnimation(frameProvider, Data);

            return animation; 
        }
    }
}