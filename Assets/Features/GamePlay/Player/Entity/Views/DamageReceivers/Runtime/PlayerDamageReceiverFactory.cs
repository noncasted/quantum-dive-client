using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    [Serializable]
    public class PlayerDamageReceiverFactory : IComponentFactory
    {
        [SerializeField] private DamageReceiverTrigger _trigger;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<DamageReceiver>()
                .WithParameter<IDamageReceiverTrigger>(_trigger)
                .As<IDamageReceiverHandler>()
                .AsCallbackListener();
        }
    }
}