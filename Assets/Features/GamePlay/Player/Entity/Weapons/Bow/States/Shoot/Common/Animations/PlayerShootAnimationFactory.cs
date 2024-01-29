using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.PlayerAnimationName, menuName = ShootRoutes.PlayerAnimationPath)]
    public class PlayerShootAnimationFactory : RotatableAnimationFactory
    {
        public PlayerShootAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new PlayerShootAnimation(frameProvider, Data);

            return animation;
        }
    }
}