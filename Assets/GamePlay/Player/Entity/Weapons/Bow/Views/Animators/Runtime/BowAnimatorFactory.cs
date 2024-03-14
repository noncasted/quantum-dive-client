using Animancer;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime
{
    [DisallowMultipleComponent]
    public class BowAnimatorFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AnimancerComponent _animator;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<BowAnimator>()
                .As<IBowAnimator>()
                .WithParameter(_animator)
                .AsCallbackListener();
        }
    }
}