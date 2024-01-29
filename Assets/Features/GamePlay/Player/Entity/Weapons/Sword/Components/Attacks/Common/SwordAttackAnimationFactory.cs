using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordAttackRoutes.AttackAnimationName,
        menuName = SwordAttackRoutes.AttackAnimationPath)]
    public class SwordAttackAnimationFactory : RotatableAnimationFactory
    {
        [SerializeField] private PlayerSwordAttackEvent _event;
        
        public SwordAttackAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new SwordAttackAnimation(frameProvider, Data, _event);

            return animation;
        }
    }
}