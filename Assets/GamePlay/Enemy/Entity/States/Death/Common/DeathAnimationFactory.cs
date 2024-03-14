using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Death.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDeathRoutes.AnimationName,
        menuName = EnemyDeathRoutes.AnimationPath)]
    public class DeathAnimationFactory : AsyncAnimationFactory
    {
        public DeathAnimation Create()
        {
            var animation = new DeathAnimation(CreateFrameProvider(), Data);

            return animation;
        }
    }
}