using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    public class SlotRegistration : IComponentFactory
    {
        private readonly SlotDefinition _definition;

        public SlotRegistration(SlotDefinition definition)
        {
            _definition = definition;
        }

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterInstance(_definition);
        }
    }
}