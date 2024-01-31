using System;
using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Internal.Services.Options.Runtime;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.Container.Runtime.ContainerBuilder;

namespace Common.Architecture.Entities.Runtime
{
    public class ScopedEntityFactory : IScopedEntityFactory
    {
        public ScopedEntityFactory(IOptions options)
        {
            _options = options;
        }

        private readonly IOptions _options;

        public UniTask<T> Create<T>(LifetimeScope parent, ScopedEntityViewFactory viewFactory,
            IScopedEntityConfig config)
        {
            return Create<T>(parent, viewFactory, config, Array.Empty<IComponentFactory>());
        }

        public async UniTask<T> Create<T>(
            LifetimeScope parent,
            ScopedEntityViewFactory viewFactory,
            IScopedEntityConfig config,
            IReadOnlyList<IComponentFactory> runtimeFactories)
        {
            var utils = CreateUtils(viewFactory);
            var builder = new ContainerBuilder();

            CreateServices(builder, utils, config, viewFactory, runtimeFactories);
            await BuildContainer(builder, utils, parent);

            return viewFactory.Scope.Container.Resolve<T>();
        }

        private IEntityUtils CreateUtils(ScopedEntityViewFactory viewFactory)
        {
            var callbacks = new EntityCallbacks();

            var utils = new EntityUtils(_options, callbacks, viewFactory.Scope);

            return utils;
        }

        private void CreateServices(
            IServiceCollection services,
            IEntityUtils utils,
            IScopedEntityConfig config,
            ScopedEntityViewFactory viewFactory,
            IReadOnlyList<IComponentFactory> runtimeFactories)
        {
            foreach (var compose in config.Composes)
            {
                foreach (var factory in compose.Factories)
                    factory.Create(services, utils);
            }

            foreach (var factory in config.Components)
                factory.Create(services, utils);

            foreach (var factory in runtimeFactories)
                factory.Create(services, utils);

            viewFactory.CreateViews(services, utils);
        }

        private async UniTask BuildContainer(
            IDependenciesBuilder builder,
            IEntityUtils utils,
            LifetimeScope parent)
        {
            using (LifetimeScope.EnqueueParent(parent))
            {
                using (LifetimeScope.Enqueue(Register))
                {
                    await UniTask.Create(async () => utils.Scope.Build());
                }
            }

            builder.ResolveAllWithCallbacks(utils.Scope.Container, utils.Callbacks);

            void Register(IContainerBuilder container)
            {
                builder.RegisterAll(container);
            }
        }
    }
}