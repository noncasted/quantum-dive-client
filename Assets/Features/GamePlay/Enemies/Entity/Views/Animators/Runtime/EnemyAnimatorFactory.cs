using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Views.Animators.Logs;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Animators.Runtime
{
    public class EnemyAnimatorFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AnimatorLogSettings _logSettings;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<AnimatorLogger>()
                .WithParameter(_logSettings);
            
            services.Register<EnemyAnimator>()
                .As<IEnemyAnimator>()
                .WithParameter(_spriteRenderer)
                .AsCallbackListener();
        }
    }
}