using Common.Architecture.Lifetimes;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public interface IScopeData
    {
        LifetimeScope Scope { get; }
        ILifetime Lifetime { get; }
    }
}