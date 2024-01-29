using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Equipment.Locker.Common;
using GamePlay.Player.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Locker.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipmentLockerRoutes.ComponentName,
        menuName = EquipmentLockerRoutes.ComponentPath)]
    public class EquipmentLockerFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<EquipmentLocker>()
                .As<IEquipmentLocker>();
        }
    }
}