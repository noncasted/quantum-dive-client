using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime
{
    [DisallowMultipleComponent]
    public class BowAnimatorFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowAnimator>()
                .As<IBowAnimator>()
                .WithParameter(_sprite)
                .AsCallbackListener();
        }
    }
}