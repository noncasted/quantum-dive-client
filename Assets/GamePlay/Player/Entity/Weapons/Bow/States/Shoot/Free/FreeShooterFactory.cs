using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Free
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.FreeComponentName,
        menuName = ShootRoutes.FreeComponentPath)]
    public class FreeShooterFactory : ShooterFactory
    {
        [SerializeField] private BaseAnimationData _playerAnimation;
        [SerializeField] private BaseAnimationData _bowAnimation;
        
        [SerializeField] private BowShootDefinition _definition;
        [SerializeField] private ShootMoveConfig _moveConfig;

        public override void Create(IServiceCollection services, IEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.CreateAnimation();
            var bowAnimation = _bowAnimation.CreateAnimation();
            
            services.Register<FreeShooter>()
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(bowAnimation, "bowAnimation")
                .WithParameter(_definition)
                .WithParameter(_moveConfig)
                .AsCallbackListener()
                .AsSelfResolvable();
        }
    }
}