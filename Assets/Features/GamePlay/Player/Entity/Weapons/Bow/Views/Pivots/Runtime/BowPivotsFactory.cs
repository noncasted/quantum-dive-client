using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime
{
    [Serializable]
    public class BowPivotsFactory : IComponentFactory
    {
        [SerializeField] private BowPivotsProvider _provider;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowPivots>()
                .As<IBowPivotsProvider>()
                .WithParameter(_provider);
        }
    }
}