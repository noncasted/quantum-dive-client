using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Factory;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Components.Equipment.Slots.Binder;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Local
{
    public class LocalEquipper : IEquipper
    {
        public LocalEquipper(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            IEquipmentFactory factory,
            IEquipperSync sync)
        {
            _storage = storage;
            _binder = binder;
            _factory = factory;
            _sync = sync;
        }

        private readonly IEquipmentSlotsStorage _storage;
        private readonly IEquipmentSlotBinder _binder;
        private readonly IEquipmentFactory _factory;
        private readonly LifetimeScope _rootScope;
        private readonly IEquipperSync _sync;

        public async UniTask Equip(IEquipmentConfig config)
        {
            var equipment = await _factory.Create(config.Local, config.Slot);
            _binder.Bind(config.Slot, equipment.Transform);
            await _storage.Equip(equipment);

            _sync.OnEquipped(config);
        }
    }
}