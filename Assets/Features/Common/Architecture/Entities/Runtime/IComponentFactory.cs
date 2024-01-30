using Common.Architecture.Container.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Entities.Runtime
{
    public interface IComponentFactory
    {
        void Create(IServiceCollection services, IEntityUtils utils);
    }
}