using System.Collections.Generic;
using Common.Architecture.Callbacks;
using Common.Architecture.Lifetimes;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Common.Architecture.Scopes.Runtime.Utils;
using Internal.Services.Scenes.Abstract;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime
{
    public class ScopeLoadResult : IScopeLoadResult
    {
        public ScopeLoadResult(
            LifetimeScope scope,
            ILifetime lifetime,
            IScopeCallbacks callbacks,
            ScopeSceneLoader sceneLoader)
        {
            _callbacks = callbacks.Handlers;
            _scenes = sceneLoader.Results;
            _scope = scope;
            _lifetime = lifetime;
        }

        private readonly IReadOnlyDictionary<CallbackStage, ICallbacksHandler> _callbacks;
        private readonly IReadOnlyList<ISceneLoadResult> _scenes;
        private readonly LifetimeScope _scope;
        private readonly ILifetime _lifetime;

        public LifetimeScope Scope => _scope;
        public ILifetime Lifetime => _lifetime;
        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Callbacks => _callbacks;
        public IReadOnlyList<ISceneLoadResult> Scenes => _scenes;
    }
}