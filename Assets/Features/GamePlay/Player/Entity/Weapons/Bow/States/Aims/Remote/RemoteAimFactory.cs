using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations;
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
        [SerializeField] [Indent] private PlayerAimAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowAimAnimationFactory _bowAnimation;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.Create();
            var bowAnimation = _bowAnimation.Create();

            services.Register<PlayerRemoteAim>()
                .WithParameter(_definition)
                .WithParameter(playerAnimation)
                .WithParameter(bowAnimation)
                .AsSelfResolvable()
                .AsCallbackListener();
        }
    }
}