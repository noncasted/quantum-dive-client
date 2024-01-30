using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime
{
    [DisallowMultipleComponent]
    public class BowArrowFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowArrow>()
                .As<IBowArrow>()
                .WithParameter(_spriteRenderer)
                .AsCallbackListener();
        }
    }
}