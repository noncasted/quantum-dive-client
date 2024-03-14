using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.LocalName,
        menuName = ShootRoutes.LocalPath)]
    public class StanceShootFactory : ShooterFactory
    {
        [SerializeField] private BaseAnimationData _playerAnimation;
        [SerializeField] private BaseAnimationData _bowAnimation;
        
        [SerializeField] [Indent] private BowShootDefinition _definition;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;
        
        public override void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.CreateAnimation();
            var bowAnimation = _bowAnimation.CreateAnimation();
            
            services.Register<StanceShoot>()
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(bowAnimation, "bowAnimation")
                .WithParameter(_definition)
                .WithParameter(_transitions)
                .AsCallbackListener();
        }
    }
}