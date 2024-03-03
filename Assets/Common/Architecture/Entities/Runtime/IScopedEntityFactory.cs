using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Common.Architecture.Entities.Runtime
{
    public interface IScopedEntityFactory
    {
        UniTask<T> Create<T>(
            LifetimeScope parent,
            ScopedEntityViewFactory viewFactory,
            IScopedEntityConfig config);
        
        UniTask<T> Create<T>(
            LifetimeScope parent,
            ScopedEntityViewFactory viewFactory,
            IScopedEntityConfig config,
            IReadOnlyList<IComponentFactory> runtimeFactories);
    }
}