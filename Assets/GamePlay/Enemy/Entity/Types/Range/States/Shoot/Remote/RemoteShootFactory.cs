using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyShootRoutes.RemoteName,
        menuName = EnemyShootRoutes.RemotePath)]
    public class RemoteShootFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private ShootDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteShoot>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}