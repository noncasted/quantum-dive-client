using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Common;
using GamePlay.Player.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipmentSlotsRoutes.ComponentName,
        menuName = EquipmentSlotsRoutes.ComponentPath)]
    public class EquipmentSlotsStorageFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<EquipmentSlotsStorage>()
                .As<IEquipmentSlotsStorage>();
        }
    }
}