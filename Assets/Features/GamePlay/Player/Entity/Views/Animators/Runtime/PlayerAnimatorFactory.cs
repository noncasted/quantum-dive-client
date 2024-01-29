using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Views.Animators.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    [Serializable]
    public class PlayerAnimatorFactory : IComponentFactory
    {
        [SerializeField] private AnimatorLogSettings _logSettings;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<AnimatorLogger>()
                .WithParameter(_logSettings);
            
            services.Register<PlayerAnimator>()
                .As<IPlayerAnimator>()
                .WithParameter(_spriteRenderer)
                .AsCallbackListener();
        }
    }
}