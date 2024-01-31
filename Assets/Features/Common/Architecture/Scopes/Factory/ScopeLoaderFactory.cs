using Common.Architecture.Scopes.Runtime;
using Common.Architecture.Scopes.Runtime.Services;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Factory
{
    public class ScopeLoaderFactory : IScopeLoaderFactory
    {
        public ScopeLoaderFactory(ISceneLoader sceneLoader, IOptions options)
        {
            _sceneLoader = sceneLoader;
            _options = options;
        }
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IOptions _options;
        
        public IScopeLoader Create(IScopeConfig config, LifetimeScope parent)
        {
            return new ScopeLoader(_sceneLoader, _options, parent, config);
        }
    }
}