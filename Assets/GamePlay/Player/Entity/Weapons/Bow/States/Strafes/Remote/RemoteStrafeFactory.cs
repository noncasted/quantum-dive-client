using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common.Animations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.RemoteName,
        menuName = BowStrafeRoutes.RemotePath)]
    public class RemoteStrafeFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private PlayerStrafeAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowStrafeAnimationFactory _bowAnimation;
        [SerializeField] [Indent] private StrafeDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.Create();
            var bowAnimation = _bowAnimation.Create();

            services.Register<PlayerRemoteStrafe>()
                .WithParameter(_definition)
                .WithParameter(playerAnimation)
                .WithParameter(bowAnimation)
                .AsCallbackListener();
        }
    }
}