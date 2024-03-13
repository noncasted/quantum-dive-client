using Internal.Scopes.Abstract.Callbacks;
using Internal.Scopes.Abstract.Options;
using Internal.Scopes.Abstract.Scenes;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public interface IServiceScopeUtils
    {
        IOptions Options { get; }
        ISceneLoader SceneLoader { get; }
        IServiceScopeBinder Binder { get; }
        IServiceScopeData Data { get; }
        ICallbacksRegistry Callbacks { get; }
        bool IsMock { get; }
    }
}