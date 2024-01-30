using Cysharp.Threading.Tasks;
using Features.GamePlay.Player.Entity.Equipment.Equipper.Factory;
using GamePlay.Player.Entity.Equipment.Abstract.Factory;
using GamePlay.Player.Entity.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Equipment.Equipper.Local
{
    public class Equipper : IEquipper
    {
        public Equipper(
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
            var equipment = await _factory.Create(config.Local);
            _binder.Bind(config.Slot, equipment.Transform);
            _storage.Equip(equipment);

            _sync.OnEquipped(config);
        }
    }
}