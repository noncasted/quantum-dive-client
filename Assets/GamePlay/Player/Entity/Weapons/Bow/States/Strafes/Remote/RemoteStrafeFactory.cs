using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.RemoteName,
        menuName = BowStrafeRoutes.RemotePath)]
    public class RemoteStrafeFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _playerAnimation;
        [SerializeField] [Indent] private BaseAnimationData _bowAnimation;
        [SerializeField] [Indent] private StrafeDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.CreateAnimation();
            var bowAnimation = _bowAnimation.CreateAnimation();

            services.Register<PlayerRemoteStrafe>()
                .WithParameter(_definition)
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(bowAnimation, "bowAnimation")
                .AsCallbackListener();
        }
    }
}