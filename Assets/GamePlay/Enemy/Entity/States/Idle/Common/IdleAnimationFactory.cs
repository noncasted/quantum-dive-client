using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Looped;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Idle.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyIdleRoutes.AnimationName,
        menuName = EnemyIdleRoutes.AnimationPath)]
    public class IdleAnimationFactory : LoopedAnimationFactory
    {
        public IdleAnimation Create()
        {
            var animation = new IdleAnimation(CreateFrameProvider(), Data);

            return animation;
        }
    }
}