using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    public class SlotRegistration : IComponentFactory
    {
        private readonly SlotDefinition _definition;

        public SlotRegistration(SlotDefinition definition)
        {
            _definition = definition;
        }

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterInstance(_definition);
        }
    }
}