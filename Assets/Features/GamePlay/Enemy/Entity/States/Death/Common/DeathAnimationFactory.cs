using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Death.Common
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