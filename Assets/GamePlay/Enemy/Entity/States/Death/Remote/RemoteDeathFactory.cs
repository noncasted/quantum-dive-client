using GamePlay.Enemy.Entity.States.Death.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Death.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDeathRoutes.RemoteName,
        menuName = EnemyDeathRoutes.RemotePath)]
    public class RemoteDeathFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private DeathDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteDeath>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}