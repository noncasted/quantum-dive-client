using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Respawn.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Respawn.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRespawnRoutes.RemoteName,
        menuName = EnemyRespawnRoutes.RemotePath)]
    public class RemoteRespawnFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private RespawnAnimationFactory _animation;
        [SerializeField] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();
            
            services.Register<RemoteRespawn>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}