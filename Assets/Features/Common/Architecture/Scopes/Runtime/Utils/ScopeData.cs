using Common.Architecture.Lifetimes;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public class ScopeData : IScopeData
    {
        public ScopeData(LifetimeScope scope, ILifetime lifetime)
        {
            _scope = scope;
            _lifetime = lifetime;
        }

        private readonly LifetimeScope _scope;
        private readonly ILifetime _lifetime;

        public LifetimeScope Scope => _scope;
        public ILifetime Lifetime => _lifetime;
    }
}