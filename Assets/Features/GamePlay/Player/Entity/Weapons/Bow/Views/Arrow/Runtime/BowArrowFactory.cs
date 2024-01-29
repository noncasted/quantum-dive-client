using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime
{
    [Serializable]
    public class BowArrowFactory : IComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowArrow>()
                .As<IBowArrow>()
                .WithParameter(_spriteRenderer)
                .AsCallbackListener();
        }
    }
}