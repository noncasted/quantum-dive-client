using Common.Architecture.Scopes.Runtime.Callbacks;
using Internal.Options.Runtime;
using Internal.Scenes.Abstract;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public interface IScopeUtils
    {
        IOptions Options { get; }
        ISceneLoader SceneLoader { get; }
        IScopeBinder Binder { get; }
        IScopeData Data { get; }
        IScopeCallbacks Callbacks { get; }
        bool IsMock { get; }
    }
}