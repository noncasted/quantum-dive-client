using GamePlay.Enemy.Entity.States.Idle.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Idle.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyIdleRoutes.RemoteName,
        menuName = EnemyIdleRoutes.RemotePath)]
    public class RemoteIdleFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private IdleDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteIdle>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}