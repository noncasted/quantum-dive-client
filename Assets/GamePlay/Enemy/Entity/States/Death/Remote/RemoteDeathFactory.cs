using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.States.Death.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Death.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDeathRoutes.RemoteName,
        menuName = EnemyDeathRoutes.RemotePath)]
    public class RemoteDeathFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private DeathAnimationFactory _animation;
        [SerializeField] private DeathDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.Create();

            services.Register<RemoteDeath>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}