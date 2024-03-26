using Animancer;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Views.Animators.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerAnimatorFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AnimancerComponent _animator;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<PlayerAnimator>()
                .As<IEnhancedAnimator>()
                .As<IPlayerAnimator>()
                .WithParameter(_animator)
                .AsCallbackListener();
        }
    }
}