using Cysharp.Threading.Tasks;
using Global.System.ScopeDisposer.Logs;
using Internal.Scenes.Abstract;
using Internal.Scopes.Abstract.Instances.Services;

namespace Global.System.ScopeDisposer.Runtime
{
    public class ScopeDisposer : IScopeDisposer
    {
        public ScopeDisposer(
            ISceneUnloader sceneUnload,
            ScopeDisposerLogger logger)
        {
            _logger = logger;
            _sceneUnload = sceneUnload;
        }

        private readonly ScopeDisposerLogger _logger;

        private readonly ISceneUnloader _sceneUnload;

        public async UniTask Unload(IServiceScopeLoadResult scopeLoadResult)
        {
            _logger.OnUnload(scopeLoadResult.Scenes.Count);

            await scopeLoadResult.Lifetime.Terminate();
            await scopeLoadResult.Callbacks.RunDispose();
            await _sceneUnload.Unload(scopeLoadResult.Scenes);

            _logger.OnUnloadingFinalized();
        }
    }
}