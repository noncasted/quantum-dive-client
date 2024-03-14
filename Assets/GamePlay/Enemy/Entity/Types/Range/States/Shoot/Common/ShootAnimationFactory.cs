using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyShootRoutes.AnimationName,
        menuName = EnemyShootRoutes.AnimationPath)]
    public class ShootAnimationFactory : AsyncAnimationFactory
    {
        [SerializeField] private EnemyShootEvent _shootEvent;
        
        public ShootAnimation Create()
        {
            var animation = new ShootAnimation(CreateFrameProvider(), Data, _shootEvent);

            return animation;
        }
    }
}