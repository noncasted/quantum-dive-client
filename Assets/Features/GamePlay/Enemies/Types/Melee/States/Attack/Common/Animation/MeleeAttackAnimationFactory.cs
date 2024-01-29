using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Common.Animation
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.AnimationName,
        menuName = EnemyMeleeAttackRoutes.AnimationPath)]
    public class MeleeAttackAnimationFactory : AsyncAnimationFactory
    {
        [SerializeField] private EnemyMeleeAttackEvent _meleeAttackEvent;
        
        public MeleeAttackAnimation Create()
        {
            var animation = new MeleeAttackAnimation(CreateFrameProvider(), Data, _meleeAttackEvent);

            return animation;
        }
    }
}