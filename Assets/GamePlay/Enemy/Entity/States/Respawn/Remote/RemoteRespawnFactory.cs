using GamePlay.Enemy.Entity.States.Respawn.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Respawn.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRespawnRoutes.RemoteName,
        menuName = EnemyRespawnRoutes.RemotePath)]
    public class RemoteRespawnFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteRespawn>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}