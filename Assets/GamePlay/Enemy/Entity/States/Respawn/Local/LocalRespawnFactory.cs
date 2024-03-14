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
        [SerializeField] private RespawnAnimationFactory _animation;
        [SerializeField] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.Create();

            services.Register<LocalRespawn>()
                .As<IRespawn>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}