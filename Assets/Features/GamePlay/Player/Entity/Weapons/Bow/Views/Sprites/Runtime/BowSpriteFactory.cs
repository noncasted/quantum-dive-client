using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime
{
    [Serializable]
    public class BowSpriteFactory : IComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowSprite>()
                .As<IBowSprite>()
                .WithParameter(_spriteRenderer);
        }
    }
}