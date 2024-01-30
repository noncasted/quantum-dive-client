using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common.Animations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.RemoteName,
        menuName = ShootRoutes.RemotePath)]
    public class RemoteShootFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BowShootAnimationFactory _bowAnimation;
        [SerializeField] [Indent] private PlayerShootAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowShootDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var bowAnimation = _bowAnimation.Create();
            var playerAnimation = _playerAnimation.Create();

            services.Register<PlayerRemoteShoot>()
                .WithParameter(bowAnimation)
                .WithParameter(playerAnimation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}