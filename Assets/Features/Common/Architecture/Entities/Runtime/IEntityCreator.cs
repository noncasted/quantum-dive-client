using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Common.Architecture.Entities.Runtime
{
    public interface IEntityCreator
    {
        UniTask<T> Create<T>(
            LifetimeScope parent,
            EntitySetupView view,
            IEntityConfig config);
        
        UniTask<T> Create<T>(
            LifetimeScope parent,
            EntitySetupView view,
            IEntityConfig config,
            IReadOnlyList<IComponentFactory> runtimeFactories);
    }
}