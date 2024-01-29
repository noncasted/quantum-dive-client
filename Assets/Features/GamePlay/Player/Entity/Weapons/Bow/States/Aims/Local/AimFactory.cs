using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowAimRoutes.LocalName, menuName = BowAimRoutes.LocalPath)]
    public class AimFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private AimDefinition _definition;
        [SerializeField] [Indent] private PlayerAimAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowAimAnimationFactory _bowAnimation;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var playerAnimation = _playerAnimation.Create();
            var bowAnimation = _bowAnimation.Create();

            services.Register<AimEntry>()
                .AsCallbackListener();
            
            services.Register<Aim>()
                .WithParameter(_definition)
                .WithParameter(_transitions)
                .WithParameter(playerAnimation)
                .WithParameter(bowAnimation)
                .As<IAim>()
                .AsSelfResolvable();
        }
    }
}