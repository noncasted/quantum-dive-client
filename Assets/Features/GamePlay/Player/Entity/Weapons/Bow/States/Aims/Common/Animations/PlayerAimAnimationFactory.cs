using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowAimRoutes.PlayerAnimationName, menuName = BowAimRoutes.PlayerAnimationPath)]
    public class PlayerAimAnimationFactory : RotatableAnimationFactory
    {
        public PlayerAimAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new PlayerAimAnimation(frameProvider, Data);

            return animation;
        }
    }
}