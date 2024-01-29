using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Damaged.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Damaged.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamagedRoutes.RemoteName,
        menuName = EnemyDamagedRoutes.RemotePath)]
    public class RemoteDamagedFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private DamagedAnimationFactory _animation;
        [SerializeField] private DamagedDefinition _definition;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();
            
            services.Register<RemoteDamaged>()
                .WithParameter(_definition)
                .WithParameter(animation)
                .AsCallbackListener();
        }
    }
}