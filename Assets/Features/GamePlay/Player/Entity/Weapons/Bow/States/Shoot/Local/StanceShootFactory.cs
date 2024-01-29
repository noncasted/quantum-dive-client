using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.LocalName,
        menuName = ShootRoutes.LocalPath)]
    public class StanceShootFactory : ShooterFactory
    {
        [SerializeField] [Indent] private BowShootAnimationFactory _bowAnimation;
        [SerializeField] [Indent] private PlayerShootAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowShootDefinition _definition;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;
        
        public override void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var bowAnimation = _bowAnimation.Create();
            var playerAnimation = _playerAnimation.Create();

            services.Register<StanceShoot>()
                .WithParameter(bowAnimation)
                .WithParameter(playerAnimation)
                .WithParameter(_definition)
                .WithParameter(_transitions)
                .AsCallbackListener();
        }
    }
}