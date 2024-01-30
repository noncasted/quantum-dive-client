using System;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Features.GamePlay.Player.Entity.Equipment.Equipper.Factory
{
    public class EquipmentFactory : IEquipmentFactory
    {
        public EquipmentFactory(
            IEntityCreator creator, 
            LifetimeScope parentScope)
        {
            _creator = creator;
            _parentScope = parentScope;
        }

        private readonly IEntityCreator _creator;
        private readonly LifetimeScope _parentScope;
        
        public async UniTask<IEquipment> Create(IEquipmentInstanceConfig config)
        {
            var view = Object.Instantiate(config.Prefab);
            var equipment = await _creator.Create<IEquipment>(_parentScope, view, config);

            return equipment;
        }
    }
}