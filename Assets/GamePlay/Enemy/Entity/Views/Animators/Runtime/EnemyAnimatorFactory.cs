using GamePlay.Enemy.Entity.Views.Animators.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Animators.Runtime
{
    public class EnemyAnimatorFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AnimatorLogSettings _logSettings;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
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