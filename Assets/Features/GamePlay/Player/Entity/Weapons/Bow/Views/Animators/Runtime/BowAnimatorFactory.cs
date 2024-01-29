using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime
{
    [Serializable]
    public class BowAnimatorFactory : IComponentFactory
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowAnimator>()
                .As<IBowAnimator>()
                .WithParameter(_sprite)
                .AsCallbackListener();
        }
    }
}