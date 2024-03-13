using Cysharp.Threading.Tasks;

namespace Internal.Scopes.Abstract.Callbacks
{
    public interface IScopeCallbacks
    {
        UniTask RunDispose();
    }
}