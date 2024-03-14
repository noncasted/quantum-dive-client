using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowAimRoutes.LocalName, menuName = BowAimRoutes.LocalPath)]
    public class AimFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private AimDefinition _definition;
        [SerializeField] [Indent] private BaseAnimationData _playerAnimation;
        [SerializeField] [Indent] private BaseAnimationData _bowAnimation;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.CreateAnimation();
            var bowAnimation = _bowAnimation.CreateAnimation();

            services.Register<AimEntry>()
                .AsCallbackListener();
            
            services.Register<Aim>()
                .WithParameter(_definition)
                .WithParameter(_transitions)
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(bowAnimation, "bowAnimation")
                .As<IAim>()
                .AsSelfResolvable();
        }
    }
}