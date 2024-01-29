using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime
{
    [Serializable]
    public class PlayerEquipmentSlotsBinderFactory : IComponentFactory
    {
        [SerializeField] private EquipmentSlotsBinder _binder;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.RegisterComponent(_binder)
                .As<IEquipmentSlotBinder>();
        }
    }
}