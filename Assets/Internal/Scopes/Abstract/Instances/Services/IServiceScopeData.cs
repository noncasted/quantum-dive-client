using Internal.Scopes.Abstract.Lifetimes;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public interface IServiceScopeData
    {
        LifetimeScope Scope { get; }
        ILifetime Lifetime { get; }
    }
}