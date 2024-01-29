using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Death.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Death.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDeathRoutes.RemoteName,
        menuName = EnemyDeathRoutes.RemotePath)]
    public class RemoteDeathFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private DeathAnimationFactory _animation;
        [SerializeField] private DeathDefinition _definition;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();

            services.Register<RemoteDeath>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}