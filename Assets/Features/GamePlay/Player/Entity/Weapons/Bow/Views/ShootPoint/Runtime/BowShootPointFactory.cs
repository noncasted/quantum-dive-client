using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    [Serializable]
    public class BowShootPointFactory : IComponentFactory
    {
        [SerializeField] private ShootPointProvider _shootPoints;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowShootPoint>()
                .As<IBowShootPoint>()
                .WithParameter(_shootPoints);
        }
    }
}