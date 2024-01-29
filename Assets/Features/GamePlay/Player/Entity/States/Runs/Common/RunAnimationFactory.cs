using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RunRoutes.RunAnimationName,
        menuName = RunRoutes.RunAnimationPath)]
    public class RunAnimationFactory : RotatableAnimationFactory
    {
        public RunAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new RunAnimation(frameProvider, Data);

            return animation;
        }
    }
}