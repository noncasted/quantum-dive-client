using Common.Architecture.Scopes.Runtime.Callbacks;
using Internal.Options.Runtime;
using Internal.Scenes.Abstract;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public class ScopeUtils : IScopeUtils
    {
        public ScopeUtils(
            IOptions options,
            ISceneLoader sceneLoader,
            IScopeBinder binder,
            IScopeData data,
            IScopeCallbacks callbacks,
            bool isMock)
        {
            _options = options;
            _sceneLoader = sceneLoader;
            _binder = binder;
            _data = data;
            _callbacks = callbacks;
            _isMock = isMock;
        }

        private readonly IOptions _options;
        private readonly ISceneLoader _sceneLoader;
        private readonly IScopeBinder _binder;
        private readonly IScopeData _data;
        private readonly IScopeCallbacks _callbacks;
        private readonly bool _isMock;

        public IOptions Options => _options;
        public ISceneLoader SceneLoader => _sceneLoader;
        public IScopeBinder Binder => _binder;
        public IScopeData Data => _data;
        public IScopeCallbacks Callbacks => _callbacks;
        public bool IsMock => _isMock;
    }
}