using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime
{
    [Serializable]
    public class BowTransformFactory : IComponentFactory
    {
        [SerializeField] private Transform _transform;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowTransform>()
                .As<IBowTransform>()
                .WithParameter(_transform);
        }
    }
}