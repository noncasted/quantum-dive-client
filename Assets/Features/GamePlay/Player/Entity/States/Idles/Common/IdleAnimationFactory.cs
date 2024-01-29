using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Idles.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = IdleRoutes.AnimationName,
        menuName = IdleRoutes.AnimationPath)]
    public class IdleAnimationFactory : RotatableAnimationFactory
    {
        public IdleAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new IdleAnimation(frameProvider, Data);

            return animation;
        }
    }
}