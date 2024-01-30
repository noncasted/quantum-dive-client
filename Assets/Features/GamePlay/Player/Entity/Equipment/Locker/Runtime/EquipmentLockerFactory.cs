using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Equipment.Locker.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Locker.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipmentLockerRoutes.ComponentName,
        menuName = EquipmentLockerRoutes.ComponentPath)]
    public class EquipmentLockerFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<EquipmentLocker>()
                .As<IEquipmentLocker>();
        }
    }
}