using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Looped;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Following.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFollowingRoutes.AnimationName,
        menuName = EnemyFollowingRoutes.AnimationPath)]
    public class FollowingAnimationFactory : LoopedAnimationFactory
    {
        public FollowingAnimation Create()
        {
            var animation = new FollowingAnimation(CreateFrameProvider(), Data);

            return animation;
        }
    }
}