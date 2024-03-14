using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Components.Equipment.Locker.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Locker.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipmentLockerRoutes.ComponentName,
        menuName = EquipmentLockerRoutes.ComponentPath)]
    public class EquipmentLockerFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EquipmentLocker>()
                .As<IEquipmentLocker>();
        }
    }
}