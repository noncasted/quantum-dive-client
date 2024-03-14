using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.States.Respawn.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Respawn.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRespawnRoutes.RemoteName,
        menuName = EnemyRespawnRoutes.RemotePath)]
    public class RemoteRespawnFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private RespawnAnimationFactory _animation;
        [SerializeField] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.Create();
            
            services.Register<RemoteRespawn>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}