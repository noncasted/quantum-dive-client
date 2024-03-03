using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.RemoteName,
        menuName = ShootRoutes.RemotePath)]
    public class RemoteShootFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BowShootDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<PlayerRemoteShoot>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}