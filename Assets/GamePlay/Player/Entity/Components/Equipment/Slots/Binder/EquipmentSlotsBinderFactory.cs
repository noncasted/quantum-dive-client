using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Binder
{
    [DisallowMultipleComponent]
    public class EquipmentSlotsBinderFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private EquipmentSlotsBinder _binder;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterComponent(_binder)
                .As<IEquipmentSlotBinder>();
        }
    }
}