using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRollRoutes.AttackAnimationName,
        menuName = PlayerRollRoutes.AttackAnimationPath)]
    public class RollAnimationFactory : RotatableAnimationFactory
    {
        public RollAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new RollAnimation(frameProvider, Data);

            return animation;
        }
    }
}