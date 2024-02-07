using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.States.Respawn.Common;
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

        public void Create(IServiceCollection services, IEntityUtils utils)
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