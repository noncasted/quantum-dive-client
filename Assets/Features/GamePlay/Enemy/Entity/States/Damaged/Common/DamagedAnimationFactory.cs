using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamagedRoutes.AnimationName,
        menuName = EnemyDamagedRoutes.AnimationPath)]
    public class DamagedAnimationFactory : AsyncAnimationFactory
    {
        public DamagedAnimation Create()
        {
            var animation = new DamagedAnimation(CreateFrameProvider(), Data);

            return animation;
        }
    }
}