using GamePlay.Player.Entity.Equipment.Abstract.Factory;
using GamePlay.Player.Entity.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using GamePlay.Player.Entity.Setup.Scope;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Equipment.Equipper.Local
{
    public class Equipper : IEquipper
    {
        public Equipper(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope rootScope,
            IEquipperSync sync)
        {
            _storage = storage;
            _binder = binder;
            _rootScope = rootScope;
            _sync = sync;
        }

        private readonly IEquipmentSlotsStorage _storage;
        private readonly IEquipmentSlotBinder _binder;
        private readonly LifetimeScope _rootScope;
        private readonly IEquipperSync _sync;

        public void Equip(IEquipmentFactory factory)
        {
            factory.CreateLocal(_storage, _binder, _rootScope)
                .Forget();

            _sync.OnEquipped(factory);
        }
    }
}