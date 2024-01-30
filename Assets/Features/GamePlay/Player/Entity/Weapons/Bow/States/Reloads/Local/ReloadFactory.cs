using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common.Animations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ReloadRoutes.LocalName, menuName = ReloadRoutes.LocalPath)]
    public class ReloadFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BowReloadAnimationFactory _bowAnimation;
        [SerializeField] [Indent] private PlayerReloadAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowReloadDefinition _definition;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var bowAnimation = _bowAnimation.Create();
            var playerAnimation = _playerAnimation.Create();

            services.Register<Reload>()
                .WithParameter(bowAnimation)
                .WithParameter(playerAnimation)
                .WithParameter(_definition)
                .WithParameter(_transitions)
                .AsCallbackListener();
        }
    }
}