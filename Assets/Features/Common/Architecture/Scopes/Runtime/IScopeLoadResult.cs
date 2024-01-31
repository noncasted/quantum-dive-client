using System.Collections.Generic;
using Common.Architecture.Callbacks;
using Common.Architecture.Lifetimes;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Internal.Services.Scenes.Abstract;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime
{
    public interface IScopeLoadResult
    {
        LifetimeScope Scope { get; }
        ILifetime Lifetime { get; }
        IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Callbacks { get; }
        IReadOnlyList<ISceneLoadResult> Scenes { get; }
    }
}