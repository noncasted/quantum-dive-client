using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Options;
using Internal.Scopes.Abstract.Scenes;
using Internal.Scopes.Runtime.Callbacks;
using Internal.Scopes.Runtime.Containers;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Lifetime = Internal.Scopes.Runtime.Lifetimes.Lifetime;

namespace Internal.Scopes.Runtime.Instances.Services
{
    public class ServiceScopeLoader : IServiceScopeLoader
    {
        public ServiceScopeLoader(
            ISceneLoader sceneLoader,
            IOptions options,
            LifetimeScope parent,
            IServiceScopeConfig config)
        {
            _sceneLoader = sceneLoader;
            _options = options;
            _parent = parent;
            _config = config;
        }

        private readonly ISceneLoader _sceneLoader;
        private readonly IOptions _options;
        private readonly LifetimeScope _parent;
        private readonly IServiceScopeConfig _config;

        public async UniTask<IServiceScopeLoadResult> Load()
        {
            var sceneLoader = new ServiceScopeSceneLoader(_sceneLoader);
            var utils = await CreateUtils(sceneLoader);
            var builder = new ServiceCollection();

            await CreateServices(builder, utils);
            await BuildContainer(builder, utils);

            var loadResult = new ScopeLoadResult(
                utils.Data.Scope,
                utils.Data.Lifetime,
                utils.InternalCallbacks,
                sceneLoader);

            return loadResult;
        }

        private async UniTask<ServiceScopeUtils> CreateUtils(ISceneLoader sceneLoader)
        {
            var servicesScene = await sceneLoader.Load(_config.ServicesScene);
            var binder = new ServiceScopeBinder(servicesScene.Scene);
            var scope = Object.Instantiate(_config.ScopePrefab);
            binder.MoveToModules(scope.gameObject);
            var lifetime = new Lifetime();
            var scopeData = new ServiceScopeData(scope, lifetime);
            var callbacks = new ScopeCallbacks();

            var utils = new ServiceScopeUtils(_options, sceneLoader, binder, scopeData, callbacks, _config.IsMock);

            return utils;
        }

        private async UniTask CreateServices(IServiceCollection builder, IServiceScopeUtils utils)
        {
            var tasks = new List<UniTask>();

            var services = new List<IServiceFactory>(_config.Services);

            foreach (var compose in _config.Composes)
                services.AddRange(compose.Factories);

            foreach (var factory in services)
                tasks.Add(factory.Create(builder, utils));

            await UniTask.WhenAll(tasks);
        }

        private async UniTask BuildContainer(ServiceCollection builder, IServiceScopeUtils utils)
        {
            using (LifetimeScope.EnqueueParent(_parent))
            {
                using (LifetimeScope.Enqueue(Register))
                {
                    await UniTask.Create(async () => utils.Data.Scope.Build());
                }
            }

            builder.Resolve(utils.Data.Scope.Container, utils.Callbacks);
            return;

            void Register(IContainerBuilder container)
            {
                builder.PassRegistrations(container);
            }
        }
    }
}