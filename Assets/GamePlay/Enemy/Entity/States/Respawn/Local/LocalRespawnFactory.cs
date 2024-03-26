using GamePlay.Enemy.Entity.States.Respawn.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Respawn.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRespawnRoutes.LocalName,
        menuName = EnemyRespawnRoutes.LocalPath)]
    public class LocalRespawnFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalRespawn>()
                .As<IRespawn>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}