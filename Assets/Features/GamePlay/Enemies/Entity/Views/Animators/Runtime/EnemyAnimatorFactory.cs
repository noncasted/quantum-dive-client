using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Views.Animators.Logs;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Animators.Runtime
{
    [Serializable]
    public class EnemyAnimatorFactory : IComponentFactory
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