using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime
{
    [DisallowMultipleComponent]
    public class BowSpriteFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowSprite>()
                .As<IBowSprite>()
                .WithParameter(_spriteRenderer);
        }
    }
}