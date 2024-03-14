using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    public class EquipmentFactory : IEquipmentFactory
    {
        public EquipmentFactory(
            IEntityScopeLoader factory,
            LifetimeScope parentScope)
        {
            _factory = factory;
            _parentScope = parentScope;
        }

        private readonly IEntityScopeLoader _factory;
        private readonly LifetimeScope _parentScope;

        public async UniTask<IEquipment> Create(IEquipmentInstanceConfig config, SlotDefinition slotDefinition)
        {
            var view = Object.Instantiate(config.Prefab);
            var slotRegistration = new SlotRegistration(slotDefinition);
            
            var equipment = await _factory.Load<IEquipment>(
                _parentScope,
                view,
                config,
                new[] { slotRegistration });

            await equipment.Construct();

            return equipment;
        }
    }
}