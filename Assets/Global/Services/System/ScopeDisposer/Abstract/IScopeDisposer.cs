using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Instances.Services;

namespace Global.System.ScopeDisposer.Runtime
{
    public interface IScopeDisposer
    {
        public UniTask Unload(IServiceScopeLoadResult scopeLoadResult);
    }
}