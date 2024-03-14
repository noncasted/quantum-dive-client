using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
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

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterInstance(_entity);
        }
    }
}