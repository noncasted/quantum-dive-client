using Common.Architecture.Entities.Runtime.Callbacks;
using Common.Architecture.Lifetimes;
using Internal.Services.Options.Runtime;
using VContainer.Unity;

namespace Common.Architecture.Entities.Runtime
{
    public interface IEntityUtils
    {
        IOptions Options { get; }
        LifetimeScope Scope { get; }
        ILifetime Lifetime { get; }
        IEntityCallbacksRegistry CallbacksRegistry { get; }
    }
}