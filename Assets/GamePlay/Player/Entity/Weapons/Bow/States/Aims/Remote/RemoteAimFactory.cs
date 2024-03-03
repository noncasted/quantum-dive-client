using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowAimRoutes.RemoteName,
        menuName = BowAimRoutes.RemotePath)]
    public class RemoteAimFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private AimDefinition _definition;
        [SerializeField] [Indent] private BaseAnimationData _playerAnimation;
        [SerializeField] [Indent] private BaseAnimationData _bowAnimation;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.CreateAnimation();
            var bowAnimation = _bowAnimation.CreateAnimation();

            services.Register<PlayerRemoteAim>()
                .WithParameter(_definition)
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(bowAnimation, "bowAnimation")
                .AsSelfResolvable()
                .AsCallbackListener();
        }
    }
}