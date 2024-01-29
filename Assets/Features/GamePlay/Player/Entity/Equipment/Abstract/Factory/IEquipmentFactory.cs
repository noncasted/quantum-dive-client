using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Equipment.Abstract.Factory
{
    public interface IEquipmentFactory
    {
        UniTaskVoid CreateLocal(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent);
        
        UniTaskVoid CreateRemote(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent);

    }
}