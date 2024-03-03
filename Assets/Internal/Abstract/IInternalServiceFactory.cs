using Internal.Options.Runtime;
using VContainer;

namespace Internal.Abstract
{
    public interface IInternalServiceFactory
    {
        void Create(IOptions options, IContainerBuilder builder);
    }
}