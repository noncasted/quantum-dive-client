using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Respawn.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRespawnRoutes.AnimationName,
        menuName = EnemyRespawnRoutes.AnimationPath)]
    public class RespawnAnimationFactory : LoopedAnimationFactory
    {
        public RespawnAnimation Create()
        {
            var animation = new RespawnAnimation(CreateFrameProvider(), Data);

            return animation;
        }
    }
}