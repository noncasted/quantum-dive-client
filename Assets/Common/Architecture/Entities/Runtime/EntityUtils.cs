using Common.Architecture.Entities.Runtime.Callbacks;
using Common.Architecture.Lifetimes;
using Internal.Options.Runtime;
using VContainer.Unity;

namespace Common.Architecture.Entities.Runtime
{
    public class EntityUtils : IEntityUtils
    {
        public EntityUtils(IOptions options, LifetimeScope scope, ILifetime lifetime, IEntityCallbacksRegistry callbacksRegistry)
        {
            _options = options;
            _scope = scope;
            _lifetime = lifetime;
            _callbacksRegistry = callbacksRegistry;
        }

        private readonly IOptions _options;
        private readonly LifetimeScope _scope;
        private readonly ILifetime _lifetime;
        private readonly IEntityCallbacksRegistry _callbacksRegistry;
        
        public IOptions Options => _options;
        public LifetimeScope Scope => _scope;
        public ILifetime Lifetime => _lifetime;
        public IEntityCallbacksRegistry CallbacksRegistry => _callbacksRegistry;
    }
}