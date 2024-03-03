using GamePlay.Player.Entity.Components.Rotations.Animation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common.Animations
    {
        [InlineEditor]
        [CreateAssetMenu(fileName = BowStrafeRoutes.PlayerAnimationName, menuName = BowStrafeRoutes.PlayerAnimationPath)]
        public class PlayerStrafeAnimationFactory : RotatableAnimationFactory
        {
            public PlayerStrafeAnimation Create()
            {
                var frameProvider = new RotatableFrameProvider(this);
                var animation = new PlayerStrafeAnimation(frameProvider, Data);

                return animation;
            }
        }
    }
