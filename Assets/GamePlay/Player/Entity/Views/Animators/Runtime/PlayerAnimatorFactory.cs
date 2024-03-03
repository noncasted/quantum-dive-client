using Animancer;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Views.Animators.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerAnimatorFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AnimatorLogSettings _logSettings;
        [SerializeField] private AnimancerComponent _animator;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<AnimatorLogger>()
                .WithParameter(_logSettings);
            
            services.Register<PlayerAnimator>()
                .As<IEnhancedAnimator>()
                .As<IPlayerAnimator>()
                .WithParameter(_animator)
                .AsCallbackListener();
        }
    }
}