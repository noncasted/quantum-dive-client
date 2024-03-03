using Common.Architecture.Container.Abstract;

namespace Common.Architecture.Entities.Runtime
{
    public interface IComponentFactory
    {
        void Create(IServiceCollection services, IEntityUtils utils);
    }
}