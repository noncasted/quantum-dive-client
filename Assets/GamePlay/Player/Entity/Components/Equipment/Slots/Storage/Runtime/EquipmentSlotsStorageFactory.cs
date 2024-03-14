using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipmentSlotsRoutes.ComponentName,
        menuName = EquipmentSlotsRoutes.ComponentPath)]
    public class EquipmentSlotsStorageFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EquipmentSlotsStorage>()
                .As<IEquipmentSlotsStorage>();
        }
    }
}