using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.Damaged.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Damaged.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamagedRoutes.LocalName,
        menuName = EnemyDamagedRoutes.LocalPath)]
    public class LocalDamagedFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private DamagedPushConfig _pushConfig;
        [SerializeField] private DamagedAnimationFactory _animation;
        [SerializeField] private DamagedDefinition _definition;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();
            
            services.Register<LocalDamaged>()
                .WithParameter<IPushConfig>(_pushConfig)
                .WithParameter(_definition)
                .WithParameter(animation)
                .As<IDamaged>()
                .AsCallbackListener();
        }
    }
}