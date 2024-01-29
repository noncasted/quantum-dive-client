using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RunRoutes.WalkAnimationName,
        menuName = RunRoutes.WalkAnimationPath)]
    public class WalkAnimationFactory : RotatableAnimationFactory
    {
        public WalkAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new WalkAnimation(frameProvider, Data);

            return animation;
        }
    }
}