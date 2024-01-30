using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Common;

using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipmentSlotsRoutes.ComponentName,
        menuName = EquipmentSlotsRoutes.ComponentPath)]
    public class EquipmentSlotsStorageFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<EquipmentSlotsStorage>()
                .As<IEquipmentSlotsStorage>();
        }
    }
}