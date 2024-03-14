using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
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
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<PlayerRemoteShoot>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}