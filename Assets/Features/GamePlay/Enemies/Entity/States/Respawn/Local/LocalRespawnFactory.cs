using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Respawn.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Respawn.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRespawnRoutes.LocalName,
        menuName = EnemyRespawnRoutes.LocalPath)]
    public class LocalRespawnFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private RespawnAnimationFactory _animation;
        [SerializeField] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
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