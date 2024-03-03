using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    public class EquipmentFactory : IEquipmentFactory
    {
        public EquipmentFactory(
            IScopedEntityFactory factory,
            LifetimeScope parentScope)
        {
            _factory = factory;
            _parentScope = parentScope;
        }

        private readonly IScopedEntityFactory _factory;
        private readonly LifetimeScope _parentScope;

        public async UniTask<IEquipment> Create(IEquipmentInstanceConfig config, SlotDefinition slotDefinition)
        {
            var view = Object.Instantiate(config.Prefab);
            var slotRegistration = new SlotRegistration(slotDefinition);
            
            var equipment = await _factory.Create<IEquipment>(
                _parentScope,
                view,
                config,
                new[] { slotRegistration });

            return equipment;
        }
    }
}