using System.Collections.Generic;
using GamePlay.Player.Entity.Equipment.Abstract.Factory;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Setup.Scope;
using GamePlay.Player.Services.Registries.Equipment.Runtime;
using Ragon.Client;
using Ragon.Protocol;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Equipment.Equipper.Remote
{
    public class RemoteEquipper : RagonProperty, IEquipperSync
    {
        public RemoteEquipper(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope rootScope,
            IEquipmentRegistry registry,
            IEntityProvider entityProvider) : base(0, false)
        {
            _storage = storage;
            _binder = binder;
            _rootScope = rootScope;
            _registry = registry;
            _entityProvider = entityProvider;
        }
        
        private readonly IEquipmentSlotsStorage _storage;
        private readonly IEquipmentSlotBinder _binder;
        private readonly LifetimeScope _rootScope;
        private readonly IEquipmentRegistry _registry;
        private readonly IEntityProvider _entityProvider;

        private readonly List<int> _buffer = new();
        private readonly List<int> _equipped = new();

        public void OnEquipped(IEquipmentFactory equipmentFactory)
        {
            var id = _registry.GetId(equipmentFactory);

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
                
                Equip(factory);
            }

            foreach (var id in _equipped)
            {
                if (_buffer.Contains(id) == true)
                    continue;
                
                //TODO: Remote equipment
            }
        }
        
        private void Equip(IEquipmentFactory factory)
        {
            factory.CreateRemote(_storage, _binder, _rootScope)
                .Forget();
        }
    }
}