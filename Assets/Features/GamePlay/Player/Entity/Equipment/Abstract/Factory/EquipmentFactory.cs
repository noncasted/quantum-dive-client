using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Equipment.Abstract.Factory
{
    public abstract class EquipmentFactory : ScriptableObject, IEquipmentFactory
    {
        public abstract UniTaskVoid CreateLocal(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent);

        public abstract UniTaskVoid CreateRemote(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent);
    }
}