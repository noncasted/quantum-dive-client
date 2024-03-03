using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Ragon.Client;

namespace GamePlay.Player.Factory.Factory.Runtime
{
    public class EntityComponentFactory : IComponentFactory
    {
        public EntityComponentFactory(RagonEntity entity)
        {
            _entity = entity;
        }

        private readonly RagonEntity _entity;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterInstance(_entity);
        }
    }
}