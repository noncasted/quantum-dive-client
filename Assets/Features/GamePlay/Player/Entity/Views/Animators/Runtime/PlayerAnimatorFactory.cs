using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Views.Animators.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerAnimatorFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AnimatorLogSettings _logSettings;
        [SerializeField] private Animator _animator;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<AnimatorLogger>()
                .WithParameter(_logSettings);
            
            services.Register<PlayerAnimator>()
                .As<IPlayerAnimator>()
                .WithParameter(_animator)
                .AsCallbackListener();
        }
    }
}