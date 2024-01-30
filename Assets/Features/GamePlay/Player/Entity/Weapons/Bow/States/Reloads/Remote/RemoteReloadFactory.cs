using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Common.Animations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ReloadRoutes.RemoteName,
        menuName = ReloadRoutes.RemotePath)]
    public class RemoteReloadFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BowReloadAnimationFactory _bowAnimation;
        [SerializeField] [Indent] private PlayerReloadAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowReloadDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var bowAnimation = _bowAnimation.Create();
            var playerAnimation = _playerAnimation.Create();

            services.Register<PlayerRemoteReload>()
                .WithParameter(bowAnimation)
                .WithParameter(playerAnimation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}