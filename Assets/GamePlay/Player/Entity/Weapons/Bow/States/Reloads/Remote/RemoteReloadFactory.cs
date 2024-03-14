using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ReloadRoutes.RemoteName,
        menuName = ReloadRoutes.RemotePath)]
    public class RemoteReloadFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _bowAnimation;
        [SerializeField] [Indent] private BaseAnimationData _playerAnimation;
        [SerializeField] [Indent] private BowReloadDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var bowAnimation = _bowAnimation.CreateAnimation();
            var playerAnimation = _playerAnimation.CreateAnimation();

            services.Register<PlayerRemoteReload>()
                .WithParameter(bowAnimation, "bowAnimation")
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}