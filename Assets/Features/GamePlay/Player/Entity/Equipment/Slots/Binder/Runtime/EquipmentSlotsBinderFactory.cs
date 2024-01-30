using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime
{
    [DisallowMultipleComponent]
    public class EquipmentSlotsBinderFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private EquipmentSlotsBinder _binder;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterComponent(_binder)
                .As<IEquipmentSlotBinder>();
        }
    }
}