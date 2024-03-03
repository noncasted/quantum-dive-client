using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common.Animations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ReloadRoutes.PlayerAnimationName, menuName = ReloadRoutes.PlayerAnimationPath)]
    public class PlayerReloadAnimationFactory : RotatableAnimationFactory
    {
        public PlayerReloadAnimation Create()
        {
            var frameProvider = new RotatableFrameProvider(this);
            var animation = new PlayerReloadAnimation(frameProvider, Data);

            return animation;
        }
    }
}