using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ReloadRoutes.LocalName, menuName = ReloadRoutes.LocalPath)]
    public class ReloadFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _bowAnimation;
        [SerializeField] [Indent] private BaseAnimationData _playerAnimation;
        [SerializeField] [Indent] private BowReloadDefinition _definition;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var bowAnimation = _bowAnimation.CreateAnimation();
            var playerAnimation = _playerAnimation.CreateAnimation();

            services.Register<Reload>()
                .WithParameter(bowAnimation, "bowAnimation")
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(_definition)
                .WithParameter(_transitions)
                .AsCallbackListener();
        }
    }
}