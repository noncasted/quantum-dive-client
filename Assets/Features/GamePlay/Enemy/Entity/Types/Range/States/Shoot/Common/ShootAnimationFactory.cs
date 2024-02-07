using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Range.States.Shoot.Common
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