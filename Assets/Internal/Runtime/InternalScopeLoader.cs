using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Runtime.Instances.Entities;
using Internal.Scopes.Runtime.Instances.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Internal.Runtime
{
    public class InternalScopeLoader
    {
        public InternalScopeLoader(IInternalScopeConfig config)
        {
            _config = config;
        }

        private readonly IInternalScopeConfig _config;

        public async UniTask<LifetimeScope> Load()
        {
            _config.Options.Setup();
            
            var scope = Object.Instantiate(_config.Scope);

            using (LifetimeScope.Enqueue(Register))
            {
                await UniTask.Create(async () => scope.Build());
            }

            void Register(IContainerBuilder services)
            {
                foreach (var service in _config.Services)
                    service.Create(_config.Options, services);

                services.RegisterInstance(_config.Options);
                services.Register<ServiceScopeLoader>(Lifetime.Singleton)
                    .As<IServiceScopeLoader>();
                services.Register<EntityScopeLoader>(Lifetime.Singleton)
                    .As<IEntityScopeLoader>();

            }

            return scope;
        }
    }
}