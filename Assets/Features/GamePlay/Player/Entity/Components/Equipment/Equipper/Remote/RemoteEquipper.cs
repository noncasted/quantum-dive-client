using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Factory;
using GamePlay.Player.Entity.Components.Equipment.Slots.Binder;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Services.Mappers.Equipment.Runtime;
using Ragon.Client;
using Ragon.Protocol;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Remote
{
    public class RemoteEquipper : RagonProperty, IEquipperSync
    {
        public RemoteEquipper(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            IEquipmentFactory factory,
            IPlayerEquipmentMapper registry,
            IEntityProvider entityProvider) : base(0, false)
        {
            _storage = storage;
            _binder = binder;
            _factory = factory;
            _registry = registry;
            _entityProvider = entityProvider;
        }
        
        private readonly IEquipmentSlotsStorage _storage;
        private readonly IEquipmentSlotBinder _binder;
        private readonly IEquipmentFactory _factory;
        private readonly LifetimeScope _rootScope;
        private readonly IPlayerEquipmentMapper _registry;
        private readonly IEntityProvider _entityProvider;

        private readonly List<int> _buffer = new();
        private readonly List<int> _equipped = new();

        public void OnEquipped(IEquipmentConfig equipmentConfig)
        {
            var id = _registry.GetId(equipmentConfig);

            _buffer.Add(id);
            MarkAsChanged();
        }

        public override void Serialize(RagonBuffer buffer)
        {
            var count = _buffer.Count;

            buffer.WriteInt(count, 0, 256);

            foreach (var id in _buffer)
                buffer.WriteInt(id, 0, 256);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var count = buffer.ReadInt(0, 256);
            
            _buffer.Clear();

            for (var i = 0; i < count; i++)
                _buffer.Add(buffer.ReadInt(0, 256));

            if (_entityProvider.IsMine == true)
                return;

            foreach (var id in _buffer)
            {
                if (_equipped.Contains(id) == true)
                    continue;

                _equipped.Add(id);
                
                var factory = _registry.GetFactory(id);
                
                Equip(factory).Forget();
            }

            foreach (var id in _equipped)
            {
                if (_buffer.Contains(id) == true)
                    continue;
                
                //TODO: Remote equipment
            }
        }
        
        private async UniTask Equip(IEquipmentConfig config)
        {
            var equipment = await _factory.Create(config.Local);
            _binder.Bind(config.Slot, equipment.Transform);
            _storage.Equip(equipment);
        }
    }
}