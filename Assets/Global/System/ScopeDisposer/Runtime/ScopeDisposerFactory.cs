using Cysharp.Threading.Tasks;
using Global.System.ScopeDisposer.Abstract;
using Global.System.ScopeDisposer.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ScopeDisposer.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScopeDisposerRoutes.ServiceName,
        menuName = ScopeDisposerRoutes.ServicePath)]
    public class ScopeDisposerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<ScopeDisposer>()
                .As<IScopeDisposer>();
        }
    }
}