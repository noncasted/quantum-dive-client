using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Following.Common
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