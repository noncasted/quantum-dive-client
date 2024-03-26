using GamePlay.Enemy.Entity.States.Damaged.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamagedRoutes.RemoteName,
        menuName = EnemyDamagedRoutes.RemotePath)]
    public class RemoteDamagedFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private DamagedDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteDamaged>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}