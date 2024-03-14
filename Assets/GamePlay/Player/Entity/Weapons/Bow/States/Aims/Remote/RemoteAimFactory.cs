using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
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
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
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